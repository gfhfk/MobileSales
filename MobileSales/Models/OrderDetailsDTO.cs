using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileSales.Models
{
    public class OrderDetailsDTO
    {
        public OrderDetailsDTO()
        {
        }
        public OrderDetailsDTO(OrderDetails orderDetails)
        {
            OrderDetailsID= orderDetails.OrderDetailsID;
            OrderID=orderDetails.OrderID;
            ProductID=orderDetails.ProductID;
            ProductName=orderDetails.Product.ProductName;
            Price=orderDetails.Product.Price;
            Quantity=orderDetails.Quantity;
        }
        [Key]
        public int  OrderDetailsID{ get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sum
        {
            get { return Math.Round(Quantity*Price); }
        }
        

        
    }
}