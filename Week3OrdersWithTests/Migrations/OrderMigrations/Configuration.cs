using Week3OrdersWithTests.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CsvHelper;

namespace Week3OrdersWithTests.Migrations.OrderMigrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Week3OrdersWithTests.Models.BusinessDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\OrderMigrations";
        }

        protected override void Seed(Week3OrdersWithTests.Models.BusinessDBContext context)
        {
            //Seed4Customers(context);
            //SeedProductData(context);
            importProductsCSV(context);
        }

        private void Seed4Customers(BusinessDBContext context)
        {
            Random random = new Random();

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer
                {
                    Name = "Joe Bloggs",
                    Address = "Ash Lane, Co.Sligo",
                    CreditRating = random.Next(2000, 4000)
                });

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer
                {
                    Name = "Mary Browne",
                    Address = "Ballina, Co.Mayo",
                    CreditRating = random.Next(2000, 4000)
                });

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer
                {
                    Name = "Paddy McGuinley",
                    Address = "Tuam Road, Co.Galway",
                    CreditRating = random.Next(2000, 4000)
                });

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer
                {
                    Name = "Pat Short",
                    Address = "1 Fake Street, Co.Dublin",
                    CreditRating = random.Next(2000, 4000)
                });

        }

        private void SeedProductData(BusinessDBContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Week3OrdersWithTests.Models.Stuff.Products.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    var products = csvReader.GetRecords<Product>().ToArray();
                    context.Products.AddOrUpdate(s => s.ID, products);
                }
            }
            context.SaveChanges();

        }
        public static Product FromCsv(string csvLine)
        {
            Random random = new Random();
            // Get data and assign each value
            string[] values = csvLine.Split(',');
            Product ProductData = new Product();
            ProductData.Description = values[0];
            ProductData.StockOnHand = Convert.ToInt32(values[1]);
            ProductData.ReorderLevel = Convert.ToInt32(values[2]);
            ProductData.ReorderQuantity = 20;
            ProductData.UnitPrice = random.Next(3, 8);

            return ProductData;
        }

        private void importProductsCSV(BusinessDBContext context)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Week3OrdersWithTests.Models.Stuff.Products.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    var products = csvReader.GetRecords<Product>().ToArray();
                    foreach (var data in products)
                    {
                        context.Products.AddOrUpdate(c =>
                        new { c.ID, c.Description },
                        new Product
                        {
                            Description = data.Description,
                            StockOnHand = data.StockOnHand,
                            ReorderLevel = data.ReorderLevel
                        });

                    }
                }
            }
        }
    }
}
