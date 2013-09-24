using MobileSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Mvc;

namespace MobileSales.Controllers
{
    public class ProductTypesController : EntitySetController<ProductType, int>
    {
        private MobileSalesContext db = new MobileSalesContext();

        public override IQueryable<ProductType> Get()
        {

            return db.ProductTypes; ;
        }
        protected override ProductType GetEntityByKey(int key)
        {
            return db.ProductTypes.FirstOrDefault(o => o.ProductTypeID== key);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}