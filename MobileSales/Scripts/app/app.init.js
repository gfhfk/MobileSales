/// <reference path="../_references.js" />

window.MSalesApp = {};

 $(function () {
    
     //var dev = DevExpress.devices.current("desktop");
     //console.log(dev);
     var devices = DevExpress.devices;
     
     //var defaultLayout = "slideout";
     var defaultLayout = "slideout";
     if (devices.current().platform === "desktop") {
         defaultLayout = "desktop";
     }

     var navigationManager = new DevExpress.framework.NavigationManager();
     navigationManager.navigated.add(function (args) {
         var newUri = document.location.hash.replace(/^#+/, "");
         if (args.uri != newUri) {
             args.item.uri = newUri;
             args.item.key = newUri;
         }
     })

     MSalesApp.app = new DevExpress.framework.html.HtmlApplication({
         namespace: MSalesApp,

         defaultLayout: defaultLayout,
        navigation: [
          {
              title: "Routes",
              action: "#routes",
              icon: "home"
          },
          {
              title: "About",
              action: "#about",
              icon: "info"
          }
        ],
    });
     MSalesApp.app.router.register(":view/:id", { view: "routes", id: undefined });
     MSalesApp.app.navigate();
    
     
    
});
