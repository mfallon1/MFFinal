using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace MFFinal
{
    internal class DisplayAllCatProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DisplayAllCatProd()
        {
            var db = new NorthwindContext();
            var query = db.Categories.Include("Products").OrderBy(p => p.CategoryId); // dont do .ToList() after because we can add to it with where etc.
            Console.Clear();
            Console.WriteLine("NORTHWIND Category & Products - Display Category and related Products\n");
            foreach (var item in query)
            {
                Console.WriteLine($"\n{item.CategoryName}:");
                //                GetProductCount(item.CategoryId); // display the product count first
                GetProductCount getProductCount = new GetProductCount(item.CategoryId); // display the product count first

                foreach (Product p in item.Products)
                {
                    if (!p.Discontinued)
                    Console.WriteLine($"\t{p.ProductName}");
                }
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }
    }
}