using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal
{
    internal class EditCat
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EditCat()
        {
            var db = new NorthwindContext();  //
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

            Console.WriteLine("Enter a new Category name");
            var newname = Console.ReadLine(); // get the name 
            Console.WriteLine("Enter new Category description");
            logger.Info($"{newname}");
            category.CategoryName = newname;
            // update naem and db - this works because we have it from above
            //    db.Categories.Add(category);
            db.SaveChanges();

        }
    }
}