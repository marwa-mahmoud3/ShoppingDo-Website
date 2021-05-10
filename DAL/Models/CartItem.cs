using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CartItem
    {
        public int ID { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }
        public virtual Product product { get; set; }
        
        [ForeignKey("cart")]
        public int CartID { get; set; }
        public virtual Cart cart { get; set; }
    }
}
