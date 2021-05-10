using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The category Name is required.")]
        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}
