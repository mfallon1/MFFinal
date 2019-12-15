using MFFinal.Models;
using System;
using System.Linq;

namespace MFFinal
{
    internal class DisplayCat 
    {
        public DisplayCat() // display all the categories
        {
            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(p => p.CategoryName);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - Display CATEGORIES\n");
            Console.WriteLine($"There are {query.Count()} Categories:");
            foreach (var item in query)
            {
                Console.WriteLine($"\t{item.CategoryName} - {item.Description}");
            }
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }

        public static string DispCatSel() // display the list of categories for selection
        {

            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(p => p.CategoryId);
            Console.WriteLine($"There are {query.Count()} Categories:");

            foreach (var item in query)
            {
                Console.WriteLine($"\t{item.CategoryId}) {item.CategoryName} - {item.Description} ");
            }
            Console.WriteLine("\nType the Category Id and Press ENTER...");
            string catid = Console.ReadLine();
            return catid;
        }
    }
}