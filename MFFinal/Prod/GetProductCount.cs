using MFFinal.Models;
using System;
using System.Linq;

namespace MFFinal
{
    internal class GetProductCount
    {
        private int id;

        public GetProductCount(int id)  // get product count for Category
        {
            this.id = id;
            var db = new NorthwindContext();
            var cquery = db.Products.Where(p => p.CategoryId == id && !p.Discontinued).Count();
            Console.WriteLine($"\n** {cquery} Product(s) returned\n");
        }
    }
}