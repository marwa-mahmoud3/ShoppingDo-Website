using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [DisplayName("Product Image")]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public virtual Category category { get; set; }
        public virtual Brands brand { get; set; }
    }
}
