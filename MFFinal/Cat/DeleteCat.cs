using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal
{
    internal class DeleteCat
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        int id;

        public DeleteCat()
        {
            var db = new NorthwindContext();
            Console.Clear();
            Console.WriteLine("NORTHWIND Category & Products - Delete Category and related Products\n");
            Console.WriteLine("Select the category you want to Delete:");
            try
                {
                id = int.Parse(DisplayCat.DispCatSel()); // display the list of categories

                Console.Clear();
                Console.WriteLine("NORTHWIND Category & Products - Delete Category and related Products\n");
                logger.Info($"CategoryId {id} selected");


                Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                Console.WriteLine($"You chose {category.CategoryName} - {category.Description}");

                GetProductCount getProductCount = new GetProductCount(id); // display the product count first

                foreach (Product p in category.Products) // products enumerated in the category bcause of the list
                {
                    Console.WriteLine($"\t{p.ProductName}");
                }

                Console.WriteLine("Delete the Category and any related Products? Y or any key to bypass");
                string del = Console.ReadLine();
                logger.Info($"{del}");


                if (del.ToUpper() == "Y")
                {
                    var dquery = db.Products.Where(p => p.CategoryId == id);
                    foreach (var item in dquery)
                    {
                        db.Products.Remove(item);
                        db.SaveChanges();
                    }
                    var delcat = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                    db.Categories.Remove(delcat);
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("** No Category selected");
                Console.ResetColor();
            }
        }
    }

}