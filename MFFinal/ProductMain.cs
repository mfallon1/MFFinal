using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MFFinal
{
    internal class ProductMain
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        string choice = "";
        char selection;
        public ProductMain()
        {
            do
            {
                var productmenu = new ProductMenu();

                if (selection.Equals('q'))
                {
                    break;
                }
                choice = selection.ToString();
                logger.Info("User choice: {Choice}", choice);

                if (choice == "1") // display the categories
                {
                    DisplayCat displayCat = new DisplayCat();
                }

                else if (choice == "2") // Add a category
                {
                    AddCat addCat = new AddCat();
                }

                else if (choice == "3")  // Display the category and its products
                {
                    DisplayCatProd displayCatProd = new DisplayCatProd();
                }

                else if (choice == "4")
                {
                    DisplayAllCatProd displayAllCatProd = new DisplayAllCatProd();  // Display all categories and related products
                }

                else if (choice == "5")
                {
                    EditCat editCat = new EditCat();  // Edit a category
                }


            } while (!selection.Equals('q'));
        }
    }
}