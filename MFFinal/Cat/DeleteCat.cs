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
        public DeleteCat()
        {
            var db = new NorthwindContext();
            //string newname;
            //string newdesc;
            //
            Console.WriteLine("Select the category you want to edit:");

            int id = int.Parse(DisplayCat.DispCatSel()); // display the list of categories

            //var query = db.Categories.OrderBy(p => p.CategoryId);

            //Console.WriteLine("Select the category you want to edit:");
            //foreach (var item in query)
            //{
            //    Console.WriteLine($"{item.CategoryId}) {item.CategoryName}");
            //}
            //int id = int.Parse(Console.ReadLine());
            Console.Clear();
            logger.Info($"CategoryId {id} selected");

            // get the record
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id); // get the record context - is connected to the database - have to get the context first to update it
            Console.WriteLine($"You chose {category.CategoryName} - {category.Description}");
            logger.Info($" {category.CategoryName} - {category.Description}");

            var cquery = db.Products.Where(p => p.CategoryId == id).Count();
            Console.WriteLine($"\n** {cquery} Product(s) will be deleted\n");

            Console.WriteLine("Edit Category Name? Y/N");
            string edit = Console.ReadLine();
            logger.Info($"{edit}");


            if (edit.ToLower() == "y")
            {
                Console.WriteLine("Enter a new Category name");
                newname = Console.ReadLine(); // get the name 
                logger.Info($"{newname}");
                category.CategoryName = newname;
            }

            Console.WriteLine("Edit Category Description? Y/N");
            edit = Console.ReadLine();
            logger.Info($"{edit}");

            if (edit.ToLower() == "y")
            {
                Console.WriteLine("Enter new Category description");
                newdesc = Console.ReadLine();
                category.Description = newdesc;
                logger.Info($"{newdesc}");
            }
            // update naem and db - this works because we have it from above
            //    db.Categories.Add(category);
            db.SaveChanges();

        }
    }
    }
}