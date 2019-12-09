using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{
    class DisplayAProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public DisplayAProd()
        {
            var db = new NorthwindContext();

            Console.WriteLine("Enter the Product Id you would like displayed:");

            int id = int.Parse(DisplayProd.DisplayProdSel()); // display the list of categories

            Console.Clear();
            logger.Info($"ProductId {id} selected");
            try
            {
                Product product = db.Products.FirstOrDefault(c => c.ProductID == id);

                Console.WriteLine($"You chose:  {product.ProductName} ");
                Console.WriteLine($"Category Id: {product.CategoryId}  Supplier Id: {product.SupplierId}");
                Console.WriteLine($"Quantity Per Unit: {product.QuantityPerUnit}");
                Console.WriteLine($"Unit Price: {product.UnitPrice}");
                Console.WriteLine($"Units in stock: {product.UnitsInStock}");
                Console.WriteLine($"Units On Order: {product.UnitsOnOrder}");
                Console.WriteLine($"ReOrder Level: {product.ReorderLevel}\n");


                product.Discontinued = false;
                Console.WriteLine("Is the Item Discontinued?  Y or anything else for Active");
                string disc = Console.ReadLine();
                disc = disc.ToLower();
                if (disc == "y")
                {
                    product.Discontinued = true;
                }
            }
            catch
            {
                logger.Info("Error in Selection");
                Console.WriteLine($"** Error - Try again");
            }
        }
    }
}
