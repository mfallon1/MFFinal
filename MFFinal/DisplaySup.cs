using MFFinal.Models;
using System;
using System.Linq;


namespace MFFinal
{
    class DisplaySup
    {
            public static string DisplaySupSel() // display all the categories
            {
                var db = new NorthwindContext();
                var query = db.Suppliers.OrderBy(p => p.SupplierId);

                Console.WriteLine($"There are {query.Count()} Suppliers:");
                foreach (var item in query)
                {
                Console.WriteLine($" {item.SupplierId}) {item.CompanyName}");
                }

            string supid = Console.ReadLine();
            return supid;

        }

            //public static string DispCatSel() // display the list of categories for selection
            //{

            //    var db = new NorthwindContext();
            //    var query = db.Categories.OrderBy(p => p.CategoryId);

            //    foreach (var item in query)
            //    {
            //        Console.WriteLine($" {item.CategoryId}) {item.CategoryName}");
            //    }

            //    string catid = Console.ReadLine();
            //    return catid;
            //}
    }

}
