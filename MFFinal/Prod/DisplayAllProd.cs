using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFFinal.Models;
using NLog;

namespace MFFinal.Prod
{
    internal class DisplayAllProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public DisplayAllProd() // display all the products
        {
            logger.Info("Program started");
            string choice = "";
            char selection;
            var db = new NorthwindContext();
            int qcount = 0;
            int m = 0;
            string qsel = "Y";
            IQueryable<Product> query = db.Products.OrderBy(p => p.ProductName); 

            do
            {
                var selprodmenu = new SelProdMenu();  // display the menu and return the selection

                selection = char.ToLower(selprodmenu.GetSelInput());
                if (selection.Equals('q'))
                {
                    break;
                }
                choice = selection.ToString();
                logger.Info("User choice: {Choice}", choice);

                if (choice == "1") //  all Products
                {
                     Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("NORTHWIND Category & Products - Display all PRODUCTS\n");

                    break;
                }
                else if (choice == "2") // Products active
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("NORTHWIND Category & Products - Display active PRODUCTS\n");
                    query = db.Products.Where(p => !p.Discontinued )
                                            .OrderBy(p => p.ProductName);
                    break;
                }
                else if (choice == "3") // Products discontinued
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("NORTHWIND Category & Products - Display discontinued PRODUCTS\n");
                    query = db.Products.Where(p => p.Discontinued)
                                            .OrderBy(p => p.ProductName);
                    break;
                }

            } while (!selection.Equals('q'));

            qcount = query.Count();
            Console.WriteLine($"** There are {query.Count()} Products:");
            foreach (var item in query)
            {
                string active = "Active";
                if (item.Discontinued)
                {
                    active = "Discontinued";
                }
                //else
                Console.WriteLine($"\t{item.ProductName} - {active}");
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
            Console.Write("\nFinished - Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
