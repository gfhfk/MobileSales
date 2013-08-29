using MobileSales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.ModelBinding;
namespace MobileSales.Controllers
{
    public class OrderDetailsDTOController : EntitySetController<OrderDetailsDTO, int>
    {
        private MobileSalesContext db = new MobileSalesContext();
        public override IQueryable<OrderDetailsDTO> Get()
        {

            return db.OrderDetails.Include(od => od.Product).
                Select(od => new OrderDetailsDTO
                {
                    OrderDetailsID = od.OrderDetailsID,
                    OrderID = od.OrderID,
                    Price = od.Product.Price,
                    ProductID = od.ProductID,
                    ProductName = od.Product.ProductName,
                    Quantity = od.Quantity
                }
                );
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}
