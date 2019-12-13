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
            //string newname;
            //string newdesc;
            //
            Console.WriteLine("Select the category you want to Delete:");

            id = int.Parse(DisplayCat.DispCatSel()); // display the list of categories

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
            //Console.WriteLine($"You selected: {category.CategoryName} - {category.Description}");
            logger.Info($" {category.CategoryName} - {category.Description}");

            var cquery = db.Products.Where(p => p.CategoryId == id).Count();
            Console.WriteLine($"\n** You selected: {category.CategoryName} {category.Description} - with {cquery} Product(s)\n");

            Console.WriteLine("Delete the Category and its Products? Y/N");
            string del = Console.ReadLine();
            logger.Info($"{del}");


            if (del.ToUpper() == "Y")
            {
                var dquery = db.Products.Where(p => p.CategoryId == id);
                foreach (var item in dquery)
                {
                    db.Products.Remove(item);
                    //db.SaveChanges();
                }
                var delcat = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                db.Categories.Remove(delcat);
                db.SaveChanges();
            }
        }
    }

}