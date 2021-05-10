using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class OffersViewModel
    {
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public double discount { get; set; }
        public virtual Product Product { get; set; }

    }
}
