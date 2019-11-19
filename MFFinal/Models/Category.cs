using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFFinal.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "** Category Name must be entered")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "** Category Description must be entered")]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}
