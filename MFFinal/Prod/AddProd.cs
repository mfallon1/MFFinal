﻿using MFFinal.Models;
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
        static string s;
        int id;
        string suppliername;
        string categoryname;

        bool badentry = true;
        public AddProd()
        {
            var db = new NorthwindContext();
            Product product = new Product();
            Console.Clear();
            Console.WriteLine("Northwind Products - Add a Product\n");
            do
            {
                try
                {
                    Console.WriteLine("Enter the Category Id for this product:");

                    s = DisplayCat.DispCatSel(); // display the list of categories

                    if (CustomMethod.IsInt(s))
                    {
                        id = Int16.Parse(s); // try to parse
                        if (db.Categories.Any(p => p.CategoryId == id)) //validate the ID entered
                        {
                            Console.Clear();
                            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                            logger.Info($"CategoryId {id} selected");
                            categoryname = category.CategoryName;
                            product.CategoryId = id;
                            badentry = false;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("** Incorrect CategoryID selected");
                            logger.Info($"Incorrect CategoryId selected");
                            Console.ResetColor();
                        }
                    }
                }
                catch
                {
                    logger.Info($"incorrect CategoryId selected");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Incorrect CategoryID selected");
                    Console.ResetColor();
                }
            } while (badentry);


            badentry = true;

            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine("\nEnter the Supplier Id for this product:");
            do
            {
                try
                {
                    s = DisplaySup.DisplaySupSel(); // display the list of Suppliers
                    if (CustomMethod.IsBlank(s))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("** Must enter something");
                        logger.Info("blank supplier entered");
                        Console.ResetColor();
                    }
                    else
                    {
                        id = Int16.Parse(s); // try to parse
                        if (db.Suppliers.Any(p => p.SupplierId == id)) //validate the ID entered
                        {
                            Supplier supplier = db.Suppliers.FirstOrDefault(c => c.SupplierId == id);
                            Console.Clear();
                            suppliername = supplier.CompanyName;
                            logger.Info($"SupplierId {id} selected");
                            product.SupplierId = id;
                            badentry = false;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("** Incorrect SupplierID selected");
                            logger.Info($"Incorrect SupplierId selected");
                            Console.ResetColor();
                        }
                    }
                }
                catch
                {
                    logger.Info($"incorrect SupplierId selected");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Incorrect SupplierID selected");
                    Console.ResetColor();
                }
            } while (badentry);


            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");


            do
            {
                Console.WriteLine("\nProduct Name:");  //validate the product name
                s = Console.ReadLine();
                product.ProductName = s;

                if (CustomMethod.IsBlank(s))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Must enter something");
                    logger.Info("blank Name entered");
                    Console.ResetColor();
                }

            } while (CustomMethod.IsBlank(s));


            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");

            do
            {
                Console.WriteLine("\nEnter the Quantity Per Unit - Example 24 per box:"); // qty per unit

                s = Console.ReadLine();
                product.QuantityPerUnit = s;
                if (CustomMethod.IsBlank(s))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Must enter something");
                    Console.ResetColor();
                    logger.Info("blank Qty Per Unit entered");
                }
                
            } while (CustomMethod.IsBlank(s));

            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");
            Console.WriteLine($"\tQuantity Per Unit: {product.QuantityPerUnit}");
            do
            {

                Console.WriteLine("\nUnit Price as 0.00:");  // unit price
                s = Console.ReadLine();

                if (CustomMethod.IsDec(s))
                {
                    logger.Info($"Good Price Entered {s}");
                    product.UnitPrice = Convert.ToDecimal(s);
                    logger.Info($"{s} Unit Price");

                }
                else
                {
                    logger.Info($"bad Price Entered {s}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a Decimal");
                    Console.ResetColor();
                }

            } while (!CustomMethod.IsDec(s));

            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");
            Console.WriteLine($"\tQuantity Per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"\tUnit Price: {product.UnitPrice}");
            do
            {
                Console.WriteLine("\nEnter the number of Units In Stock:"); // units in stock
                s = Console.ReadLine();

                if (CustomMethod.IsInt(s))
                {
                    logger.Info($"Units In Stock {s}");
                    product.UnitsInStock = Convert.ToInt16(s);
                   
                }
                else
                {
                    logger.Info($"bad Units in Stock Entered {s}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Not a valid number");
                    Console.ResetColor();
                }

            } while (!CustomMethod.IsInt(s));

            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");
            Console.WriteLine($"\tQuantity Per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"\tUnit Price: {product.UnitPrice}");
            Console.WriteLine($"\tUnits In Stock: {product.UnitsInStock}");
            do
            {

                Console.WriteLine("\nEnter the number of Units On Order:"); // units on order
                s = Console.ReadLine();
                if (CustomMethod.IsInt(s))
                {
                    logger.Info($"Units On Order {s}");
                    product.UnitsOnOrder = Convert.ToInt16(s);

                }
                else
                {
                    logger.Info($"bad Units On Order Entered {s}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Not a valid number");
                    Console.ResetColor();
                }

            } while (!CustomMethod.IsInt(s));

            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");
            Console.WriteLine($"\tQuantity Per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"\tUnit Price: {product.UnitPrice}");
            Console.WriteLine($"\tUnits In Stock: {product.UnitsInStock}");
            Console.WriteLine($"\tUnits On Order: {product.UnitsOnOrder}");
            do
            {

                Console.WriteLine("\nEnter the Reorder Level count:");  // reorder count
                s = Console.ReadLine();

                if (CustomMethod.IsInt(s))
                {
                    logger.Info($"Reorder Level {s}");
                    product.ReorderLevel = Convert.ToInt16(s);

                }
                else
                {
                    logger.Info($"bad Reorder Level {s}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** Not a valid number");
                    Console.ResetColor();

                }

            } while (!CustomMethod.IsInt(s));

            Console.Clear();
            Console.WriteLine("\n\nNorthwind Products - Add a Product\n");
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"\tCategoryId: {product.CategoryId} {categoryname}");
            Console.WriteLine($"\tSupplier Id: {product.SupplierId} {suppliername}");
            Console.WriteLine($"\tQuantity Per Unit: {product.QuantityPerUnit}");
            Console.WriteLine($"\tUnit Price: {product.UnitPrice}");
            Console.WriteLine($"\tUnits In Stock: {product.UnitsInStock}");
            Console.WriteLine($"\tUnits On Order: {product.UnitsOnOrder}");
            Console.WriteLine($"\tReOrder Level: {product.ReorderLevel}");


            product.Discontinued = false;
            Console.WriteLine("\nIs the Item Discontinued?  Y or anything else for Active");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(erro);
                    Console.ResetColor();
                }

                // check for unique name
                if (db.Products.Any(c => c.ProductName == product.ProductName))
                {
                    // generate validation error
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    results.Add(new ValidationResult("****Sorry this Product Name exists - Please try again ", new string[] { "ProductName" }));
                    Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("* PRODUCT NOT ADDED *");
                foreach (var result in results)
                {
                    logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                    Console.WriteLine($"ERROR: {result.ErrorMessage}");
                }
                Console.ResetColor();
                Console.ReadLine();
            }

        }
    }
}
