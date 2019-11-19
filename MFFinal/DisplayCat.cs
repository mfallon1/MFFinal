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

            Console.WriteLine($"There are {query.Count()} Categories:");
            foreach (var item in query)
            {
                Console.WriteLine($"\t{item.CategoryName} - {item.Description}");
            }

        }

        public static string DispCatSel() // display the list of categories for selection
        {

            var db = new NorthwindContext();
            var query = db.Categories.OrderBy(p => p.CategoryId);
            
            foreach (var item in query)
            {
                Console.WriteLine($" {item.CategoryId}) {item.CategoryName}");
            }

            string catid = Console.ReadLine();
            return catid;
        }
    }
}