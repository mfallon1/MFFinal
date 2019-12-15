using MFFinal.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MFFinal.Prod
{
    internal class DeleteProd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        int id;

        public DeleteProd()
        {
            var db = new NorthwindContext();
            Console.Clear();
            Console.WriteLine("NORTHWIND Category & Products - Delete Products\n");
            Console.WriteLine("Select the Product you want to Delete:");
            try
            {
                int id = int.Parse(DisplayProd.DisplayProdSel()); // display the list of Products It returns the ID of the selection

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("NORTHWIND Category & Products - Delete PRODUCT\n");
                logger.Info($"ProductID {id} selected");


                Product product = db.Products.FirstOrDefault(p => p.ProductID == id); // get the record context - is connected to the database - have to get the context first to update it
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
                    Console.WriteLine($"\tCategory Id: {item.CategoryId} {item.CategoryName}");
                    Console.WriteLine($"\tSupplier Id: {item.SupplierId} {item.CompanyName}");
                    Console.WriteLine($"\tQuantity Per Unit: {item.QuantityPerUnit}");
                    Console.WriteLine($"\tUnit Price: {item.UnitPrice}");
                    Console.WriteLine($"\tUnits in stock: {item.UnitsInStock}");
                    Console.WriteLine($"\tUnits On Order: {item.UnitsOnOrder}");
                    Console.WriteLine($"\tReOrder Level: {item.ReorderLevel}\n");
                }

                Console.WriteLine("Delete the Product? Y or any key to bypass");
                string del = Console.ReadLine();
                logger.Info($"{del}");

                if (del.ToUpper() == "Y")
                {
                    //var dquery = db.Products.Where(p => p.ProductID == id);
                    //foreach (var item in dquery)
                    //{
                        db.Products.Remove(product);
                        db.SaveChanges();
                    //}
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("** No Product selected");
                Console.ResetColor();
            }
        }
    }
}
