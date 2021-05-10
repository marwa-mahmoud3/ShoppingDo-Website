using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class CartItemViewModel
    {
        public int ID { get; set; }

        public int productId { get; set; }
        public virtual Product product { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int CartID { get; set; }
    }
}
