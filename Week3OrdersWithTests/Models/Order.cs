using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Week3OrdersWithTests.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Order Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name ="Order Date")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Creator")]
        public string EnteredBy { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        //Navigational Properties
        public Customer Customer { get; set; }
        public virtual ICollection<OrderLine> Orderlines { get; set; } //Collection of Products in Order
    }
}