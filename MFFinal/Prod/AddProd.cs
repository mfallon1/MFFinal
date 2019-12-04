using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{

    internal class AddProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        string price;
        string sunits;
        static string s;

        bool badentry = true;
        public AddProd()
        {
            var db = new NorthwindContext();
            Product product = new Product();

            do
            {

                Console.WriteLine("Northwind Products - Add a Product\n");
                Console.WriteLine("Enter the Category Id for this product:");

                s = DisplayCat.DispCatSel(); // display the list of categories

                if (CustomMethod.IsBlank(s))
                {
                    Console.WriteLine("\t**Must enter something");
                    logger.Info("blank Name entered");
                }
                else 
                {
                    int id = Int16.Parse(s); // display the list of categories
                    if (db.Products.Any(p => p.ProductID == s)
                }

                Console.Clear();
                logger.Info($"CategoryId {id} selected");
                product.CategoryId = id;
            } while (CustomMethod.IsBlank(s));


            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"CategoryId {id} selected\n");
            Console.WriteLine("Enter the Supplier Id for this product:");

            int sid = int.Parse(DisplaySup.DisplaySupSel()); // display the list of Suppliers
            Console.Clear();
            logger.Info($"SupplierId {sid} selected");
            product.SupplierId = sid;

            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Category Id: {id}, Supplier Id: {sid}\n");

            //Product product = new Product();
            do
            { 
            Console.WriteLine("Product Name:");

            s = Console.ReadLine();
                if (CustomMethod.IsBlank(s))
                {
                    Console.WriteLine("\t**Must enter something");
                    logger.Info("blank Name entered");
                }
                else
                    product.ProductName = s;
            }
            while (CustomMethod.IsBlank(s));

            Console.WriteLine("Enter the Quantity Per Unit - Example 24 per box:");
            product.QuantityPerUnit = Console.ReadLine();
            try
            {
                //do
                //{
                    Console.WriteLine("Unit Price as 0.00:");
                    price = Console.ReadLine();
                    decimal decprice;

                    if (Decimal.TryParse(price, out decprice))
                    {
                        logger.Info($"Good Price Entered {price}");
                        product.UnitPrice = decprice;
                        //badentry = false;
                    }
                    else
                        Console.WriteLine("Not a Decimal");

                //    //string Abprice = Math.Abs(price);
                //} while (badentry);
            }
            catch
            {
                logger.Info($"bad Price Entered {price}");
                Console.WriteLine("Not a Decimal");
            }

            try
            {
                Console.WriteLine("Enter the number of Units In Stock:");
                sunits = Console.ReadLine();
                Int16 intunits;

                if (Int16.TryParse(sunits, out intunits))
                {
                    logger.Info($"Units In Stock {sunits}");
                    product.UnitsInStock = intunits;
                }
                else
                { 
                    logger.Info($"bad Units in Stock Entered {sunits}");
                    Console.WriteLine("Not an Integer");
                }
            }
            catch
            {
                Console.WriteLine("Not an Integer");
                logger.Info($"not an integer Units In Stock {sunits}");
            }


            //try
            //{
                Console.WriteLine("Enter the number of Units On Order:");
                sunits = Console.ReadLine();
                Int16 intnunits;

                if (Int16.TryParse(sunits, out intnunits))
                {
                    logger.Info($"Units On Order {sunits}");
                    product.UnitsOnOrder = intnunits;
                }
            //    else
            //    { 
            //        //logger.Info($"bad Units On Order Entered {sunits}");
            //        //Console.WriteLine("Not an Integer");
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("Not an Integer");
            //    logger.Info($"bad Units On Order Entered {sunits}");
            //}


            try
            {
                Console.WriteLine("Enter the number for Reorder Level:");
                sunits = Console.ReadLine();
                Int16 intunits;

                if (Int16.TryParse(sunits, out intunits))
                {
                    logger.Info($"Reorder Level {sunits}");
                    product.ReorderLevel = intunits;
                }
                else
                { }
                //    logger.Info($"bad Reorder Level {sunits}");
                //Console.WriteLine("Not an Integer");
            }
            catch
            {
                Console.WriteLine("Not an Integer");
                logger.Info($"bad Reorder Level {sunits}");
            }

            product.Discontinued = false;
            Console.WriteLine("Is the Item Discontinued?  Y/N");
            string disc = Console.ReadLine();
            disc = disc.ToLower();
            if (disc == "y")
            {
                product.Discontinued = true;               
            }


            ValidationContext context = new ValidationContext(product, null, null); // what do I want to validate? = product put product in our context
            List<ValidationResult> results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(product, context, results, true); // validate product and return it to results = bool
            if (isValid)
            {
                 db = new NorthwindContext();
                db.Products.Add(product);
                var erro = db.GetValidationErrors();
                if (erro.Any()) 
                {
                    Console.WriteLine(erro);
                }

                // check for unique name
                if (db.Products.Any(c => c.ProductName == product.ProductName))
                {
                    // generate validation error
                    isValid = false;
                    results.Add(new ValidationResult("****Sorry this Product Name exists - Please try again ", new string[] {"ProductName"}));
                }
                else 

                {
                    logger.Info("Validation passed");

                    db.SaveChanges();
                    Console.Clear();
                }
            }

            if (!isValid)
            {
                Console.WriteLine("* PRODUCT NOT ADDED *");
                foreach (var result in results)
                {
                    logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                    Console.WriteLine($"ERROR: {result.ErrorMessage}");
                }
            }

        }
    }
}
