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
                selection = char.ToLower(productmenu.GetProdInput());
                choice = selection.ToString();
                logger.Info("User choice: {Choice}", choice);

                if (choice == "1") // display the categories
                {
                    Prod.DisplayAllProd displayallProd = new Prod.DisplayAllProd();
                }

                else if (choice == "2") // Add a category
                {
                    Prod.AddProd addProd = new Prod.AddProd();
                }

                else if (choice == "3")  // Display the category and its products
                {
                    Prod.DisplayProd displayProd = new Prod.DisplayProd();
                }

                else if (choice == "4")
                {
                    Prod.EditProd editProd = new Prod.EditProd();  // Edit a product
                }

                //else if (choice == "5")
                //{
                //    EditCat editCat = new EditCat();  // Edit a category
                //}


            } while (!selection.Equals('q'));
        }
    }
}