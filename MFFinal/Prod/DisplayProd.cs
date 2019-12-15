using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{
    internal class DisplayProd
    {

        public DisplayProd() // display all the Products
        {
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductID);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - Display all PRODUCTS\n");
            Console.WriteLine($"There are {query.Count()} Products:");
            foreach (var item in query)
            {
                Console.WriteLine($"\t{item.ProductID}) - {item.ProductName}");
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        public static string DisplayProdSel() // display all the Products
        {
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductID);

            Console.WriteLine($"There are {query.Count()} Products:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductID}) - {item.ProductName}");
            }
            Console.WriteLine("\nType the Product ID and press ENTER:");
            string prodid = Console.ReadLine();
            return prodid;
        }
    }
}
