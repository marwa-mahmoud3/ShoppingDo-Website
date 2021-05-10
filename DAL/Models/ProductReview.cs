using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProductReview
    {
        public int ID { set; get; }
        public string Comment { set; get; }
        [ForeignKey("product")]
        public int productID { set; get; }
        public virtual Product product { set; get; }
        [ForeignKey("user")]
        public string userID { set; get; }
        public virtual ApplicationUser user { set; get; }
    }
}
