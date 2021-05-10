using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class OrderItemViewModel
    {
        public int ID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int OrderItemQuantity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
     
        [Display(Name = "Total Price")]
        public double productTotal { get; set; }
        [Display(Name = "Discount")]
        public double productDiscount { get; set; }
        [Display(Name = "Net Price")]
        public double ProductNetPrice { get; set; }
        public int DateOrdered { get; set; }
        [Required]
        public double OrderProductPrice { get; set; }
        public virtual Product product { get; set; }
    }
}
