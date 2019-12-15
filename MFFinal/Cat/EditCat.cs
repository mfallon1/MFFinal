using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal
{
    internal class EditCat
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static string s;
        bool badentry = true;

        public EditCat()
        {
            var db = new NorthwindContext();
            string newname;
            string newdesc;
            //
            try
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("NORTHWIND Category & Products - Edit CATEGORIES\n");
                Console.WriteLine("Select the category you want to edit:");

                int id = int.Parse(DisplayCat.DispCatSel()); // display the list of categories

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("NORTHWIND Category & Products - Edit CATEGORIES\n");
                logger.Info($"CategoryId {id} selected");

                // get the record
                Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id); // get the record context - is connected to the database - have to get the context first to update it
                Console.WriteLine($"You chose {category.CategoryName} - {category.Description}\n");
                logger.Info($" {category.CategoryName} - {category.Description}");

                Console.WriteLine("Edit Category Name? Y or press any key to bypass");
                string edit = Console.ReadLine();
                logger.Info($"{edit}");


                if (edit.ToLower() == "y")
                {
                    badentry = true;
                    do
                    {
                        Console.WriteLine("Enter a new Category name");
                        s = Console.ReadLine();
                        newname = s; // get the new name 
                        if (CustomMethod.IsBlank(s))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("** Must enter something");
                            logger.Info("blank category entered");
                            Console.ResetColor();
                        }
                        else
                        {
                            logger.Info($"{newname}");
                            badentry = false;
                            logger.Info("Validation passed");
                            category.CategoryName = newname;
                            break;
                        }
                    } while (badentry);
                }
                else
                    category.CategoryName = category.CategoryName;

                Console.WriteLine("Edit Category Description? Y or press any key to bypass");
                edit = Console.ReadLine(); // get the new description
                logger.Info($"{edit}");

                if (edit.ToLower() == "y")
                {
                    badentry = true;
                    do
                    {
                        Console.WriteLine("Enter new Category description");
                        s = Console.ReadLine();
                        newdesc = s;
                        if (CustomMethod.IsBlank(s))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("** Must enter something");
                            logger.Info("blank category desc entered");
                            Console.ResetColor();
                        }
                        else
                        {
                            badentry = false;
                            category.Description = newdesc;
                            logger.Info($"{newdesc}");
                            break;
                        }
                    } while (badentry);
                }
                else
                    category.Description = category.Description;

                ValidationContext context = new ValidationContext(category, null, null); // what do I want to validate? = category put category in our context
                List<ValidationResult> results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(category, context, results, true); // validate category and return it to results = bool
                if (!isValid)
                {
                    foreach (var result in results)
                    {
                        logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                        Console.WriteLine($"ERROR: {result.ErrorMessage}");
                        Console.ResetColor();
                    }
                }
                else
                    db.SaveChanges();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                logger.Error($"no selection made");
                Console.WriteLine($"No Category Selected");
                Console.ResetColor();
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}