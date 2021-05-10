using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class TestimonialsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Jop { get; set; }
        public string Image { get; set; }
        public string Review { get; set; }

    }
}
