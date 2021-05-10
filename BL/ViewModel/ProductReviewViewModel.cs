using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class ProductReviewViewModel
    {
        public int ID { set; get; }
        public string Comment { set; get; }
        public virtual Product product { set; get; }
        public virtual ApplicationUser user { set; get; }
    }
}
