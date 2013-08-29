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
    public class RoutesController : EntitySetController<Route, int>
    {
        private MobileSalesContext db = new MobileSalesContext();
        public override IQueryable<Route> Get()
        {

            return db.Routes; ;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
