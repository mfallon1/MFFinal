using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFFinal.Models
{
    public class Product
    {
        public int ProductID { get; set; }


        [Required(ErrorMessage = "** Product Name must be entered")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "** Quantity Per Unit must be entered")]
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Units In Stock can be 0, Please enter valid integer Number")]
        public Int16? UnitsInStock { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Units On Order can be 0, Please enter valid integer Number")]
        public Int16? UnitsOnOrder { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Reorder Level can be 0, Please enter valid integer Number")]
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        [Required(ErrorMessage = "** Category Id must be entered")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "** Supplier Id must be entered")]
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
