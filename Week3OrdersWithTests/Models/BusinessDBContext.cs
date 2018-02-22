using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Week3OrdersWithTests.Models
{
    public class BusinessDBContext : DbContext
    {
        public BusinessDBContext() : base("DefaultConnection")
        {
            
        }

        public static BusinessDBContext Create()
        {
            return new BusinessDBContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}


