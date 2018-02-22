using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Week3OrdersWithTests.Models;

namespace Week3OrdersWithTests.Models
{
    public class ContextInitializer : DropCreateDatabaseAlways<BusinessDBContext>
    {
        protected override void Seed(BusinessDBContext context)
        {
            SeedProducts(context);
            SeedCustomers(context);    

            base.Seed(context);
        }

        private void SeedCustomers(BusinessDBContext context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {
                     Name = "Danny Graham",
                      CreditRating = 0,
                         Address="123 Belview Terrace",
                          Orders = new List<Order>
                          {
                              new Order
                              {
                                   EnteredBy="Bill Bloggs",
                                    OrderDate = DateTime.Parse("2016-01-09"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      }
                                  }
                              },
                              new Order
                              {
                                   EnteredBy="Fred Couples",
                                    OrderDate = DateTime.Parse("2016-01-12"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(10,20)
                                      }
                                  }
                              },

                          }
                }

            };
            customers.ForEach(c => context.Customers.Add(c));
        }

        private int GetProductID(BusinessDBContext context)
        {
            var selected = new Random().Next(0, context.Products.Count());
            var prod = context.Products.ToList().ElementAt(selected);
            return prod.ID;
        }

        private void SeedProducts(BusinessDBContext context)
        {
            var products = new List<Product>()
            {
                new Product {
                    Description ="9 inch nails",
                     ReorderLevel = 200,
                      ReorderQuantity = 1000,
                       StockOnHand = 320,
                        UnitPrice = 0.25f
                },
                new Product {
                    Description ="6 inch nails",
                     ReorderLevel = 100,
                      ReorderQuantity = 500,
                       StockOnHand = 32,
                        UnitPrice = 0.12f
                },
                new Product {
                    Description ="Glass Hammer",
                     ReorderLevel = 20,
                      ReorderQuantity = 100,
                       StockOnHand = 32,
                        UnitPrice = 50f
                },

                new Product {
                    Description ="Sledge Hammer",
                     ReorderLevel = 20,
                      ReorderQuantity = 100,
                       StockOnHand = 32,
                        UnitPrice = 42.50f
                },
                new Product {
                    Description ="Big Nuts",
                     ReorderLevel = 100,
                      ReorderQuantity = 350,
                       StockOnHand = 220,
                        UnitPrice = 1.0f
                },
                new Product {
                    Description ="Tool Box",
                     ReorderLevel = 10,
                      ReorderQuantity = 35,
                       StockOnHand = 22,
                        UnitPrice = 100.0f
                },

            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}