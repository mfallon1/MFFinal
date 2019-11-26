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
        public AddProd()
        {
            var db = new NorthwindContext();

            Console.WriteLine("Enter the Category Id for this product:");

            int id = int.Parse(DisplayCat.DispCatSel()); // display the list of categories
            Console.Clear();
            logger.Info($"CategoryId {id} selected");

            Console.WriteLine("Enter the Supplier Id for this product:");

            int sid = int.Parse(DisplaySup.DisplaySupSel()); // display the list of Suppliers
            Console.Clear();
            logger.Info($"SupplierId {id} selected");

            Product product = new Product();
            Console.WriteLine("Enter Product Name:");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Enter the Product Description:");
            //product.Description = Console.ReadLine();

            ValidationContext context = new ValidationContext(product, null, null); // what do I want to validate? = product put product in our context
            List<ValidationResult> results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(product, context, results, true); // validate product and return it to results = bool
            if (isValid)
            {
                var db = new NorthwindContext();
                db.Products.Add(product);
                var erro = db.GetValidationErrors();
                if (erro.Any()) //added in class
                {
                    Console.WriteLine(erro);
                }

                // check for unique name
                if (db.Products.Any(c => c.ProductName == product.ProductName))
                {
                    // generate validation error
                    isValid = false;
                    results.Add(new ValidationResult("Name exists", new string[] { "ProductName" }));
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
                    logger.Error($"{result.MemberNames.First()} : {result.ErrorMessage}");
                    Console.WriteLine($"ERROR: {result.ErrorMessage}");
                }
            }

        }
    }
}
