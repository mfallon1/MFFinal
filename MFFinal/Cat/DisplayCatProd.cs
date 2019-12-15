using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal
{
    internal class DisplayCatProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public DisplayCatProd()
        {
            var db = new NorthwindContext();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - Display Category and related Products\n");
            try
            {

                int id = int.Parse(DisplayCat.DispCatSel()); // display the list of categories

            Console.Clear();
            Console.WriteLine("NORTHWIND Category & Products - Display Category and related Products\n");
            logger.Info($"CategoryId {id} selected");

                Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                Console.WriteLine($"You chose {category.CategoryName} - {category.Description}");

                GetProductCount getProductCount = new GetProductCount(id); // display the product count first

                foreach (Product p in category.Products) // products enumerated in the category bcause of the list
                {
                    if (!p.Discontinued)
                    Console.WriteLine($"\t{p.ProductName}");
                }
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
            catch
            {
                logger.Info("Error in Selection");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"** Error - Try again");
                Console.ResetColor();
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }
}