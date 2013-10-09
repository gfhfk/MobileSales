/// <reference path="../_references.js" />



//Route ViewModel
window.MSalesApp.routes = function (params) {
    logger = MSalesApp.logger;
    var viewModel = {
        routeList: {
            load: function (loadOptions) {
                if (loadOptions.refresh) {
                    var deferred = new $.Deferred();
                    var result = MSalesApp.dataservice.getAllRoutes();
                    MSalesApp.dataservice.getAllRoutes()
                        .then(function (data) {
                            deferred.resolve(data.results);
                        }).fail(function (error) {
                            logger.error("Load data error. Try later.");
                            logger.log(error);
                        });
                    return deferred;
                }
            }
        }
    };
	return viewModel;
};

//customers ViewModel
window.MSalesApp.customers = function (params) {
    logger = MSalesApp.logger;
	var skip = 0;
	var PAGE_SIZE = 10;
	var viewModel = {
	    routeId: params.id,
		searchString: ko.observable(''),
		showSearch: ko.observable(false),
		find: function () {
			viewModel.showSearch(!viewModel.showSearch());
			viewModel.searchString('');
		},
		customerList: {
			changed: new $.Callbacks(),
			load: function (loadOptions) {
				if (loadOptions.refresh) {
					skip = 0;
				}
				var deferred = new $.Deferred();
				var predicate = new breeze.Predicate("CustomerName", "substringof", viewModel.searchString())
			            .and( "RouteID", "eq", viewModel.routeId);
			    MSalesApp.dataservice.getCustomersByPredicate(predicate, skip, PAGE_SIZE)
                    .then(function (data) {
                        skip += PAGE_SIZE;
                        deferred.resolve(data.results);
                    }).fail(function (error) {
                        logger.error("Load data error. Try later.");
                        logger.log(error);
                    });
				return deferred;
			}
		}
	};
	ko.computed(function () {
		return viewModel.searchString();
	}).extend({
		throttle: 500
	}).subscribe(function () {
	    viewModel.customerList.changed.fire();
	});
	return viewModel;
};

window.MSalesApp.orders = function (params) {
    logger = MSalesApp.logger;
    var viewModel = {
        customerID: params.id,
        orderList: {
            load: function (loadOptions) {
                if (loadOptions.refresh) {
                    var deferred = new $.Deferred();
                    var result = MSalesApp.dataservice.getAllRoutes();
                    MSalesApp.dataservice.getOrdersByCustomer(viewModel.customerID)
                        .then(function (data) {
                            deferred.resolve(data.results);
                        }).fail(function (error) {
                            logger.error("Load data error. Try later.");
                            logger.log(error);
                        });
                    return deferred;
                }
            }
        }
    }
    return viewModel;
};
window.MSalesApp.orderDetails = function (params) {
    logger = MSalesApp.logger;
    var viewModel = {
        orderID: params.id,
        title: ko.observable(''),
        orderDetailList: {
            load: function (loadOptions) {
                if (loadOptions.refresh) {
                 MSalesApp.dataservice.getOrderLocally(params.id)
                    .then(function (result) {
                        viewModel.title(Globalize.format(result.entity.Date(), 'yyyy-MM-dd'));
                    }).fail(function (error) {
                        logger.error("Load data error. Try later.");
                        logger.log(error);
                    });
                    var deferred = new $.Deferred();
                    var result = MSalesApp.dataservice.getAllRoutes();
                    MSalesApp.dataservice.getOrderDetailsById(viewModel.orderID)
                        .then(function (data) {
                            deferred.resolve(data.results);
                        }).fail(function (error) {
                            logger.error("Load data error. Try later.");
                            logger.log(error);
                        });
                    return deferred;
                }
            }
        }
    }
    return viewModel;
};
window.MSalesApp.createOrder = function (params) {
    logger = MSalesApp.logger;
    var viewModel = {
        customerID: params.id,
        steps: [
            { text: "New Order" },
            { text: "Select Products" },
            { text: "Summary" }
        ],
        backBtntext: ko.observable('Cancel'),
        nextBtntext: ko.observable('Next'),
        currentStep:ko.observable(0),
        newOrder: ko.observable(createOrder(params.id)),
        showSearch: ko.observable(false),
        overlayVisible: ko.observable(false),
        productTypeId: ko.observable(0),
        productTypes: ko.observableArray(),
        display : ko.observable("0"),
        find: function () {
            viewModel.showSearch(!viewModel.showSearch());
            viewModel.productTypeId(0);
        },
        productList: {
            load: function (loadOptions) {
                if (loadOptions.refresh) {
                    var deferred = new $.Deferred();
                    MSalesApp.dataservice.getAllProducts(viewModel.productTypeId)
                        .then(function (data) {
                            var mapped = $.map(data.results, function (item) {
                                return {
                                    ProductID: item.ProductID,
                                    ProductName: item.ProductName,
                                    Price: item.Price,
                                    ProductTypeID: item.ProductTypeID,
                                    Quantity: ko.observable(0),
                                    filtered: ko.computed(function () {
                                        var  ret = true;
                                        if (viewModel.productTypeId() > 0 && viewModel.productTypeId() != item.ProductTypeID())
                                            ret = false;
                                        return ret;
                                    }),
                                }
                            });
                            deferred.resolve(mapped);
                        }).fail(function (error) {
                            logger.error("Load data error. Try later.");
                            logger.log(error);
                        });
                    return deferred;
                }
            }
        },
        previousStep: previousStep,
        nextStep: nextStep,
        cancelOrder: cancelOrder,
        showOverlay: showOverlay,
        hideOverlay:hideOverlay,
    };
    
    MSalesApp.dataservice.getAllProductTypes().
        then(function (data) {
            viewModel.productTypes = data.results;
            viewModel.productTypes.unshift({ProductTypeID:0,ProductTypeName:"All..."});
        });

    function cancelOrder() {
        if (!confirm("Are you sure you want to cancel this Oreder?"))
            return;
        MSalesApp.app.navigate("orders/" + viewModel.customerID);

    }
    function previousStep() {
        viewModel.currentStep(viewModel.currentStep() - 1);
    };
    function nextStep() {
        viewModel.currentStep(viewModel.currentStep() + 1);
    };

    function createOrder(customerID) {

        return MSalesApp.dataservice.createOrder(customerID);
    };
    viewModel.currentStep.subscribe(function (value) {
        if (value == 0) {
            viewModel.backBtntext("Cancel");
        } else {
            viewModel.backBtntext("Back");
        }
        if (value == viewModel.steps.length-1) {
            viewModel.nextBtntext("Save");
        } else {
            viewModel.nextBtntext("Next");
        }

    });

    function showOverlay (data){
        viewModel.overlayVisible(true);
    };
    function hideOverlay() {
        viewModel.overlayVisible(false);
    };

    return viewModel;
}



//MSalesApp['customer-details'] = function (params) {
//	var viewModel = {
//		id: parseInt(params.id),
//		name: ko.observable(''),
//		address: ko.observable(''),
//        comment:ko.observable('')
//	};
//	var data = MyApp.manager.getEntityByKey("Customer", viewModel.id);

//	viewModel.name(data.CustomerName());
//	viewModel.address(data.Address());
//	viewModel.comment(data.Comment());

	
//	return viewModel;
//};
