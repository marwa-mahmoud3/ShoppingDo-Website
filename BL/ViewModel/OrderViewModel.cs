using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public  class OrderViewModel
    {
        public int ID { get; set; }

        public string OrderStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public double? Discount { get; set; }

        public string address { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}
