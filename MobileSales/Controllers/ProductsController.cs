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
    public class ProductsController : EntitySetController<Product, int>
    {
        private MobileSalesContext db = new MobileSalesContext();

        public override IQueryable<Product> Get()
        {

            return db.Products; ;
        }
        protected override Product GetEntityByKey(int key)
        {
            return db.Products.FirstOrDefault(o => o.ProductID == key);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
