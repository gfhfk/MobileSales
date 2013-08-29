using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileSales.Models
{
    public class ProductType
    {
        public int ProductTypeID { get; set; }
        [Required]
        [StringLength(30)]
        public string ProductTypeName { get; set; }

    }
}