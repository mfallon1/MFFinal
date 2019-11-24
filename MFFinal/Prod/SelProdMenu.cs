using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MFFinal.Prod
{
    internal class SelProdMenu
    {
        public SelProdMenu()
        {
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Products - Do you want to see:");
            Console.WriteLine();
            Console.WriteLine("1) All Products");
            Console.WriteLine("2) Active Products");
            Console.WriteLine("3) Discontinued Products");
            Console.WriteLine("\"q\" to quit");
            Console.WriteLine();

            // input selection
        }

        public char GetSelInput()
        {
            char selection;

            while (!IsPrSelValid(Console.ReadKey(true).KeyChar, out selection))
            {

                Console.WriteLine($"Invalid input: {selection}");
                Console.WriteLine();
                Console.WriteLine("Please enter a valid menu choice");
                Console.Write("");
            }

            Console.WriteLine();
            return selection;

        }

        private bool IsPrSelValid(char input, out char selection) //validation
        {
            char[] validValues = { '1', '2', '3', 'q' };
            selection = input;
            if (validValues.Contains(input))
            {
                return true;
            }

            return false;
        }
    }
   
}