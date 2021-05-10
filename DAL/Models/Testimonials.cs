using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Testimonials
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Jop { get; set; }
        public string Image { get; set; }       
        public string Review { get; set; }
    }
}
