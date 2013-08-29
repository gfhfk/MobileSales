using Breeze.WebApi;
using MobileSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace MobileSales.Controllers
{
   
    public class OrdersController : EntitySetController<Order, int>
    {
        private MobileSalesContext db=new MobileSalesContext();
        //private EFContextProvider<MobileSalesContext> _contextProvider = new EFContextProvider<MobileSalesContext>();
        //private MobileSalesContext db;
        //public OrdersController()
        //{
        //    db = _contextProvider.Context;
        //}

        public override IQueryable<Order> Get()
        {

            return db.Orders; ;
        }
        protected override Order GetEntityByKey(int key)
        {
            return db.Orders.FirstOrDefault(o => o.OrderID == key);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
