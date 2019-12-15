using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{
    internal class DisplayProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static string DisplayProdSel() // display all the Products
        {
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductID);

            Console.WriteLine($"There are {query.Count()} Products:");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.ProductID}) - {item.ProductName}");
            }
            Console.WriteLine("\nType the Product ID and press ENTER:");
            string prodid = Console.ReadLine();
            return prodid;
        }

        public static string DisplayProd10() // display all the Products
        {
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductID);
            int qcount = query.Count();
            int m = 0;
            string qsel = "Y";

            Console.WriteLine($"There are {query.Count()} Products:");
            foreach (var item in query)
            { 

                Console.WriteLine($"{item.ProductID}) - {item.ProductName}");
                m++;
                if (m == qcount - 1)
                {
                    qsel = "N";
                    Console.WriteLine("\n** End of file **");
                    logger.Info("no more products to display");
                    break;
                }
                if (m == 30)
                {
                    Console.WriteLine("\n Enter to continue .....");
                    qsel = Console.ReadLine().ToUpper();
                    if (qsel == "Y" || qsel != "Y")
                    {
                        m = 0;
                    }
                }
            }
            Console.WriteLine("\nType the Product ID and press ENTER:");
            string prodid = Console.ReadLine();
            return prodid;
        }
    }
}
