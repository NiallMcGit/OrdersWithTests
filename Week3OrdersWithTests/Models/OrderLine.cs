using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Week3OrdersWithTests.Models
{
    public class OrderLine
    {
        [Key]
        [Column(Order=1)]
        [Display(Name = "Order Item")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Order")]
        [Column(Order=2)]
        [Display(Name = "Order Number")]
        public int OrderID { get; set; }
        [ForeignKey("Product")]
        [Display(Name = "Product Number")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        //Navigational Properties
        public Order Order { get; set; } //The Order this OrderLine belongs to
        public Product Product { get; set; } //The specific Product in the OrderLine
    }
}