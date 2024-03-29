﻿using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal
{
    internal class AddCat
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public AddCat()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - Add a CATEGORY\n");
            Category category = new Category();
            Console.WriteLine("Enter Category Name:");
            category.CategoryName = Console.ReadLine();
            Console.WriteLine("Enter the Category Description:");
            category.Description = Console.ReadLine();
            logger.Info($"{category.CategoryName} {category.Description}");

            ValidationContext context = new ValidationContext(category, null, null); // what do I want to validate? = category put category in our context
            List<ValidationResult> results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(category, context, results, true); // validate category and return it to results = bool
            if (isValid)
            {
                var db = new NorthwindContext();
                db.Categories.Add(category);
                var erro = db.GetValidationErrors();
                if (erro.Any()) //added in class
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    logger.Info($"{erro}");
                    Console.WriteLine(erro);
                    Console.ResetColor();
                }

                // check for unique name
                if (db.Categories.Any(c => c.CategoryName == category.CategoryName))
                {
                    // generate validation error
                    isValid = false;
                    results.Add(new ValidationResult("Name exists", new string[] { "CategoryName" }));
                }
                else
                {
                    logger.Info("Validation passed");
                    db.SaveChanges();
                }
            }
            if (!isValid)
            {
                foreach (var result in results)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                    Console.WriteLine($"ERROR: {result.ErrorMessage}");
                    Console.ResetColor();
                }
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}