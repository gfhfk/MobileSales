using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileSales.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public string Comment { get; set; }
        [ForeignKey("Route")]
        public int RouteID { get; set; }
        virtual public Route Route { get; set; }
    }
}