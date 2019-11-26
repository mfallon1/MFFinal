using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFFinal.Models;

namespace MFFinal.Prod
{
    internal class DisplayAllProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public DisplayAllProd() // display all the categories
        {
            logger.Info("Program started");
            string choice = "";
            char selection;
            var db = new NorthwindContext();
            var query = db.Products.OrderBy(p => p.ProductName); 

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
                    break;
                }
                else if (choice == "2") // Products active
                {
                    query = db.Products.Where(p => !p.Discontinued )
                                            .OrderBy(p => p.ProductName);
                    break;
                }
                else if (choice == "3") // Products discontinued
                {
                    query = db.Products.Where(p => p.Discontinued)
                                            .OrderBy(p => p.ProductName);
                    break;
                }

            } while (!selection.Equals('q'));




            Console.WriteLine($"****  There are {query.Count()} Products:");
            foreach (var item in query)
            {
                string active = "Active";
                if (item.Discontinued)
                {
                    active = "Discontinued";
                }
                else
                Console.WriteLine($"\t{item.ProductName} - {active}");
            }

        }

        public static string DispProdSel() // display the list of Products for selection
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
