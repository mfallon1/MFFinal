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
            Console.Clear();
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
        public char GetCatInput()
        {
            char selection;

            while (!IsItValid(Console.ReadKey(true).KeyChar, out selection))
            {

                Console.WriteLine($"Invalid input: {selection}");
                Console.WriteLine();
                Console.WriteLine("Please enter a valid menu choice");
                Console.Write("");
            }

            Console.WriteLine();
            return selection;

        }

        private bool IsItValid(char input, out char selection) //validation
        {
            char[] validValues = { '1', '2', '3', '4', '5', '6', 'Q', 'q' };
            selection = input;
            if (validValues.Contains(input))
            {
                return true;
            }

            return false;
        }

    }
}