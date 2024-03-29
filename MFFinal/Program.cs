﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MFFinal
{
    public class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            logger.Info("Program started");
            string choice = "";
            char selection;

            try
            {

                Console.SetWindowSize(100, 40);  // change size of the window
            }
            catch
            { }
            do
                {
                    var menu = new Menu();  // display the menu and return the selection
                    selection = char.ToLower(menu.GetInput());
                    if (selection.Equals('q'))
                    {
                        break;
                    }
                    choice = selection.ToString();
                    logger.Info("User choice: {Choice}", choice);

                    if (choice == "1") //  categories
                    {
                        var categorymain = new CategoryMain();
                    }
                    else if (choice == "2") // Products
                    {
                        var productmain = new ProductMain();
                    }

                } while (!selection.Equals('q'));

        }
    }
}
