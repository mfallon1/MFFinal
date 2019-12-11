using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{
    class DisplayProd
    {
        public static string DisplayProdSel() // display all the categories
        {
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductID);

            Console.WriteLine($"There are {query.Count()} Products:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductID}) - {item.ProductName}");
            }
            Console.WriteLine("Type the Product ID and press ENTER:");
            string prodid = Console.ReadLine();
            return prodid;
        }
    }
}
