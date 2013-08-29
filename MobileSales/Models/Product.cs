using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileSales.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }
        
    }
}