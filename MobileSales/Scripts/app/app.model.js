window.MSalesApp.model = (function (ko) {
    var dataservice;
    var model = {
        initialize: initialize
    };
    return model;
    function initialize(context) {
        dataservice = context;
        var store = dataservice.metadataStore;
        store.registerEntityTypeCtor("Order", null, orderInitializer);
        store.registerEntityTypeCtor("OrderDetails", null, orderDetailsInitializer);
    }
    
    function orderInitializer(order) {
        order.errorMessage = ko.observable();
    }

    function orderDetailsInitializer(orderDetails) {
        orderDetails.errorMessage = ko.observable();
    }
    //function Order() {
    //    this.OrderID=breeze.core.getUuid();
    //    this.Date= new Date();
    //    this.DeliveryDate = new Date() + 1;
    //}

})(ko);