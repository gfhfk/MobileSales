/// <reference path="../_references.js" />

window.MSalesApp.dataservice = (function (breeze, logger,model) {

    var serviceName = "/odata/";
    breeze.config.initializeAdapterInstances({ dataService: "OData" });
    var manager = new breeze.EntityManager(serviceName);
    
    var dataservice = {
        manager: manager,
        metadataStore: manager.metadataStore,
        getAllRoutes: getAllRoutes,
        getCustomersByPredicate: getCustomersByPredicate,
        getAllCustomers: getAllCustomers,
        getOrdersByCustomer: getOrdersByCustomer,
        getOrderDetailsById: getOrderDetailsById,
        getOrderLocally: getOrderLocally,
        createOrder: createOrder,
        getAllProducts:getAllProducts
    };
    manager.fetchMetadata()
       .then(function () {
           model.initialize(dataservice);

       })
       .fail(function () {
         

       });

  
    return dataservice;

    function getAllRoutes() {
        var query = breeze.EntityQuery.from("Routes").orderBy("RouteID");
        return manager.executeQuery(query);
    }

    function getManager() {
        return manager;
    }
    function getAllCustomers() {
        var query = breeze.EntityQuery.from("Customers")
            .orderBy("CustomerName");
        return manager.executeQuery(query);
    }
    function getCustomersByPredicate(predicate, skip, PAGE_SIZE) {
        var query = breeze.EntityQuery.from("Customers")
            .where(predicate)
            .skip(skip)
            .take(PAGE_SIZE)
            .orderBy("CustomerID");
        return manager.executeQuery(query);
    }
    function getOrdersByCustomer(customerID) {
        var query = breeze.EntityQuery.from("Orders")
        .where("CustomerID", "eq", customerID)
        .orderBy("Date");
        return manager.executeQuery(query);
    }
    function getOrderLocally(orderID) {
        return manager.fetchEntityByKey("Order", orderID, true );
    }
    function getOrderDetailsById(orderID) {
        var query = breeze.EntityQuery.from("OrderDetailsDTO")
            .where("OrderID", "eq", orderID)
            .orderBy("ProductName");
        return manager.executeQuery(query);
    }
    function createOrder(customerID) {
       // manager.fetchMetadata();
        var today = new Date();
        var tomorrow = new Date();
        tomorrow.setDate(today.getDate() + 1);
        var orderType = manager.metadataStore.getEntityType("Order");
        var newOrder = orderType.createEntity({
                OrderID: breeze.core.getUuid(),
                CustomerID: customerID,
                Date: today,
                DeliveryDate: tomorrow,
            });
      
        return manager.addEntity(newOrder);
    }


    function getAllProducts() {
        var query = breeze.EntityQuery.from("Products")
            .orderBy("ProductName");
        return manager.executeQuery(query);
    }
  



})(breeze, MSalesApp.logger,window.MSalesApp.model);