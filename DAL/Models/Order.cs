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
    public class Order
    {
        public int ID { get; set; }
        
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }  

        [ForeignKey("Users")]
        public string ApplicationUser_Id { get; set; }
        public virtual ApplicationUser Users { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
