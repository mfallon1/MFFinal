using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFFinal
{
    class Menu
    {
        public Menu()
        {
            // display choices to user
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1) Work with Categories");
            Console.WriteLine("2) Work with Products");
            Console.WriteLine("\"q\" to quit");
            Console.WriteLine();

            // input selection
        }

        public char GetInput()
        {
            char selection;

            while (!IsSelValid(Console.ReadKey(true).KeyChar, out selection))
            {

                Console.WriteLine($"Invalid input: {selection}");
                Console.WriteLine();
                Console.WriteLine("Please enter a valid menu choice");
                Console.Write("");
            }

            Console.WriteLine();
            return selection;

        }

        private bool IsSelValid(char input, out char selection) //validation
        {
            char[] validValues = { '1', '2', '3', '4', '5','6','Q', 'q' };
            selection = input;
            if (validValues.Contains(input))
            {
                return true;
            }

            return false;
        }

    }
}
