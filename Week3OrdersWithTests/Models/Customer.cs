using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Week3OrdersWithTests.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Credit Rating")]
        public float CreditRating { get; set; }

        //Navigational Properties
        public virtual ICollection<Order> Orders { get; set; } //Used to init lazy loading - Customers Orders
    }
}