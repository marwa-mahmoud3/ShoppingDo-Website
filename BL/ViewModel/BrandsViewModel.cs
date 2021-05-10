using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class BrandsViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }
    }
}
