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

            int id = int.Parse(DisplayProd.DisplayProdSel()); // display the list of Products It returns the ID of the selection

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - PRODUCT DETAIL");
            logger.Info($"ProductId {id} selected");
            try
            {
                //    Product product = db.Products.FirstOrDefault(c => c.ProductID == id);
                //   var query = db.Products.
                //Join(db.Categories, pl => pl.CategoryId, ct => ct.CategoryId,(p1, ct) => new { Products = p1, Categories = ct })
                //.Join(db.Suppliers, p2 => p2.SupplierId, s => s.SupplierId, (p2, s) => new { Products = p2, Suppliers = s })

                //.Distinct();
                var query = from p1 in db.Products
                            from cg in db.Categories 
                            from s in db.Suppliers
                            where p1.CategoryId == cg.CategoryId
                            where p1.SupplierId == s.SupplierId
                            where p1.ProductID == id
                            select new {p1.ProductID, p1.ProductName, cg.CategoryId, p1.SupplierId, p1.QuantityPerUnit, p1.UnitPrice, p1.UnitsInStock, p1.UnitsOnOrder, p1.ReorderLevel, s.CompanyName, cg.CategoryName, p1.Discontinued };
                foreach (var item in query)
                {
                    string active = "Active";
                    if (item.Discontinued)
                    {
                        active = "Discontinued";
                    }
                    Console.WriteLine($"You chose: {item.ProductID} {item.ProductName} - {active}");
                    Console.WriteLine($"Category Id: {item.CategoryId}-{item.CategoryName}");
                    Console.WriteLine($"Supplier Id:  {item.SupplierId}-{item.CompanyName}");
                    Console.WriteLine($"Quantity Per Unit: {item.QuantityPerUnit}");
                    Console.WriteLine($"Unit Price: {item.UnitPrice}");
                    Console.WriteLine($"Units in stock: {item.UnitsInStock}");
                    Console.WriteLine($"Units On Order: {item.UnitsOnOrder}");
                    Console.WriteLine($"ReOrder Level: {item.ReorderLevel}\n");
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
