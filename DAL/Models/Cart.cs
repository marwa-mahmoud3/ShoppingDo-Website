using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cart
    {
        public int ID { get; set; }

        [ForeignKey("users")]
        public string UserID { get; set; }
        public virtual ApplicationUser users { get; set; }

        public virtual List<CartItem> cartItems { get; set; } = new List<CartItem>(); 
      
    }
}
