MyApp.home = function (params) {

    var viewModel = {
        
        showSearch: ko.observable(false),
        overlayVisible: ko.observable(false),
        productTypeId: ko.observable(0),
        productTypes: ko.observableArray(),
        currentElemet: ko.observableArray(),  
        display: ko.observable("0"),
        orderDetails: ko.observableArray(),
        find: function () {
            viewModel.showSearch(!viewModel.showSearch());
            viewModel.productTypeId(0);
        },
        productList: ko.observableArray(),

        showOverlay: showOverlay,
        hideOverlay: hideOverlay,
        numberClick: numberClick,
        backspaceClick: backspaceClick,
        clearClick: clearClick
    };




    function showOverlay(data) {
        viewModel.display(String(data.Quantity()));
        viewModel.overlayVisible(true);
        viewModel.currentElemet = data;
    };
    function hideOverlay(data) {
        viewModel.currentElemet.Quantity(viewModel.display());
        viewModel.overlayVisible(false);
    };
    function numberClick(number) {
        var button = number.element.text();
        var newValue = (viewModel.display() === "0") ? button : viewModel.display() + button;
        this.display(newValue);
    };
    function clearClick(number) {
        viewModel.display("0");
    }
    function backspaceClick(number) {
        var self = viewModel;
        if (this.display().length > 1) {
            self.display(self.display().substr(0, self.display().length - 1));
        } else {
            self.display("0");
        }
    };

    return viewModel;
};