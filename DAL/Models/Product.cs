using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double price { get; set; }
        [Required]
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        [Required]
        [DisplayName("Product Image")]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }

        [ForeignKey("category")]
        public int? CategoryID { get; set; }
        
        public virtual Category category { get; set; }

        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual List<OrderItem> orderItems { get; set; } = new List<OrderItem>();

        [ForeignKey("brand")]
        public int BrandID { get; set; }   
        public virtual Brands brand { get; set; }
    }
}