using System;
using MobileSales.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace MobileSales.Controllers
{
    public class CustomersController : EntitySetController<Customer, int>

    {
        private MobileSalesContext db = new MobileSalesContext();
        public override IQueryable<Customer> Get()
        {

            return db.Customers; ;
        }
        protected override Customer GetEntityByKey(int key)
        {
            return db.Customers.FirstOrDefault(p => p.CustomerID == key);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
