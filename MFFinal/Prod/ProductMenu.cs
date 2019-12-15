using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MFFinal
{
    internal class ProductMenu
    {
        public ProductMenu()
        {
            // display choices to user
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - PRODUCTS");
            Console.WriteLine();
            Console.WriteLine("1) Display Products");
            Console.WriteLine("2) Add a Product");
            Console.WriteLine("3) Display Product Detail");
            Console.WriteLine("4) Edit a Product");
            Console.WriteLine("5) Delete Product");
            Console.WriteLine("\"q\" to quit");
            Console.WriteLine();

            // input selection
        }
        public char GetProdInput()
        {
            char selection;

            while (!IsPitValid(Console.ReadKey(true).KeyChar, out selection))
            {

                Console.WriteLine($"Invalid input: {selection}");
                Console.WriteLine();
                Console.WriteLine("Please enter a valid menu choice");
                Console.Write("");
            }

            Console.WriteLine();
            return selection;

        }

        private bool IsPitValid(char input, out char selection) //validation
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