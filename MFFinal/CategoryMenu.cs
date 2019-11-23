using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MFFinal
{
    internal class CategoryMenu
    {
        public CategoryMenu()
        {
            // display choices to user
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - CATEGORIES");
            Console.WriteLine();
            Console.WriteLine("1) Display Categories");
            Console.WriteLine("2) Add a Category");
            Console.WriteLine("3) Display Category and related products");
            Console.WriteLine("4) Display all Categories and their related products");
            Console.WriteLine("5) Edit Category");
            Console.WriteLine("6) Delete Category");
            Console.WriteLine("\"q\" to quit");
            Console.WriteLine();

            // input selection
        }
    }
}