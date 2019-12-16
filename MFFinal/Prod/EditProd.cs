using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{
    internal class EditProd
    {
            private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            static string s;
            bool badentry = true;
            int id;


        public EditProd()
            {
                var db = new NorthwindContext();

                string newname;
              
                try
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("NORTHWIND Category & Products - Edit PRODUCT\n");
                    Console.WriteLine("Select the Product you want to edit:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n** Note: Category Id & Supplier Id cannot be edited");
                    Console.ResetColor();

                int id = int.Parse(DisplayProd.DisplayProd10()); // display the list of Products It returns the ID of the selection
 
                Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("NORTHWIND Category & Products - Edit PRODUCT\n");
                    logger.Info($"ProductID {id} selected to edit");

                // get the record

                var query = from p1 in db.Products
                            from cg in db.Categories
                            from s in db.Suppliers
                            where p1.CategoryId == cg.CategoryId
                            where p1.SupplierId == s.SupplierId
                            where p1.ProductID == id
                            select new { p1.ProductID, p1.ProductName, cg.CategoryId, p1.SupplierId, p1.QuantityPerUnit, p1.UnitPrice, p1.UnitsInStock, p1.UnitsOnOrder, p1.ReorderLevel, s.CompanyName, cg.CategoryName, p1.Discontinued };

                foreach (var item in query)
                {
                    string active = "Active";
                    if (item.Discontinued)
                    {
                        active = "Discontinued";
                    }
                    Console.WriteLine($"You chose: {item.ProductID} {item.ProductName} - {active}");
                    Console.WriteLine($"\t\tCategory Id: {item.CategoryId} {item.CategoryName}");
                    Console.WriteLine($"\t\tSupplier Id: {item.SupplierId} {item.CompanyName}");
                    Console.WriteLine($"\t\tQuantity Per Unit: {item.QuantityPerUnit}");
                    Console.WriteLine($"\t\tUnit Price: {item.UnitPrice}");
                    Console.WriteLine($"\t\tUnits in stock: {item.UnitsInStock}");
                    Console.WriteLine($"\t\tUnits On Order: {item.UnitsOnOrder}");
                    Console.WriteLine($"\t\tReOrder Level: {item.ReorderLevel}\n");
                }
                Product product = db.Products.FirstOrDefault(p => p.ProductID == id); // get the record context - is connected to the database - have to get the context first to update it


                Console.WriteLine("Edit Product Name? Y or press any key to bypass");
                    string edit = Console.ReadLine();
                    logger.Info($"{edit}");

                    if (edit.ToLower() == "y")
                    {
                        badentry = true;
                        do
                        {
                            Console.WriteLine("Enter a new Product name");
                            s = Console.ReadLine();
                            newname = s; // get the new name 
                            if (CustomMethod.IsBlank(s))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("** Must enter something");
                                logger.Info("blank productname entered");
                                Console.ResetColor();
                            }
                            else
                            {
                                logger.Info($"{newname}");
                                badentry = false;
                                logger.Info("Validation passed");
                                product.ProductName = newname;
                                break;
                            }
                        } while (badentry);
                    }
                else
                    product.ProductName = product.ProductName;

                Console.WriteLine("Edit the Quantity Per Unit? Y or press any key to bypass");
                    edit = Console.ReadLine(); // new qty per unit
                    logger.Info($"{edit}");

                if (edit.ToLower() == "y")
                {
                    badentry = true;
                    do
                    {
                        Console.WriteLine("Enter new  Quantity Per Unit");
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
                }
                else
                    product.QuantityPerUnit = product.QuantityPerUnit;


                Console.WriteLine("Edit a new Unit Price? Y or press any key to bypass");
                edit = Console.ReadLine(); //  new unit price
                logger.Info($"{edit}");

                if (edit.ToLower() == "y")
                {
                    do
                    {
                        Console.WriteLine("\nUnit Price as 0.00:");
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
                }
                else
                    product.UnitPrice = product.UnitPrice;

                Console.WriteLine("Edit the number of Units In Stock? Y or press any key to bypass");
                edit = Console.ReadLine(); //  new units in stock
                logger.Info($"{edit}");

                if (edit.ToLower() == "y")
                {
                    do
                    {
                        Console.WriteLine("\nEnter the number of Units In Stock:");
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
                }
                else
                    product.UnitsInStock = product.UnitsInStock;

                Console.WriteLine("Edit the number of Units On Order? Y or press any key to bypass");
                    edit = Console.ReadLine(); //  new units on order
                    logger.Info($"{edit}");

                    if (edit.ToLower() == "y")
                    {
                        do
                        {
                            Console.WriteLine("\nEnter the number of Units On Order:");
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
                    }
                     else
                     product.UnitsOnOrder = product.UnitsOnOrder;

                Console.WriteLine("Edit the Reorder Level count? Y or press any key to bypass");
                    edit = Console.ReadLine(); //  new reorder level
                    logger.Info($"{edit}");

                    if (edit.ToLower() == "y")
                    {
                        do
                        {
                            Console.WriteLine("\nEnter the Reorder Level count:");
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
                    }
                        else
                        product.ReorderLevel = product.ReorderLevel;


                Console.WriteLine("Edit Item Discontinued? Y or press any key to bypass");
                    edit = Console.ReadLine(); //  new item discontinued
                    logger.Info($"{edit}");

                    if (edit.ToLower() == "y")
                    {
                        Console.WriteLine("\nIs the Item Discontinued?  Y or anything else for Active");
                        string disc = Console.ReadLine();
                        disc = disc.ToLower();
                        if (disc == "y")
                        {
                            product.Discontinued = true;
                        }
                    }
                    else
                    product.Discontinued = product.Discontinued;
                    product.CategoryId = product.CategoryId;
                    product.SupplierId = product.SupplierId;


                ValidationContext context = new ValidationContext(product, null, null); // what do I want to validate? = category put category in our context
                List<ValidationResult> results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(product, context, results, true); // validate category and return it to results = bool
                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("* PRODUCT NOT ADDED *");
                    foreach (var result in results)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                        Console.WriteLine($"ERROR: {result.ErrorMessage}");
                        Console.ResetColor();
                    }
                    Console.ResetColor();
                }

                else
                    db.Entry(product).CurrentValues.SetValues(product);
                    db.SaveChanges();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    logger.Error($"no selection made");
                    Console.WriteLine($"Not a valid entry");
                    Console.ResetColor();
                }

                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
    }
}
