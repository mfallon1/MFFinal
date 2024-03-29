﻿using MFFinal.Models;
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
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("NORTHWIND Category & Products - Display Product Detail\n");

            try {
            int id = int.Parse(DisplayProd.DisplayProd10()); // display the list of Products It returns the ID of the selection

                logger.Info($"ProductId {id} selected");

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("NORTHWIND Category & Products - Display Product Detail\n");
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
                    Console.WriteLine($"\tCategory Id: {item.CategoryId} {item.CategoryName}");
                    Console.WriteLine($"\tSupplier Id:  {item.SupplierId} {item.CompanyName}");
                    Console.WriteLine($"\tQuantity Per Unit: {item.QuantityPerUnit}");
                    Console.WriteLine($"\tUnit Price: {item.UnitPrice}");
                    Console.WriteLine($"\tUnits in stock: {item.UnitsInStock}");
                    Console.WriteLine($"\tUnits On Order: {item.UnitsOnOrder}");
                    Console.WriteLine($"\tReOrder Level: {item.ReorderLevel}\n");
                }
            }
            catch
            {
                logger.Info("Error in Selection");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"** Error - Try again");
                Console.ResetColor();
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
   
}
