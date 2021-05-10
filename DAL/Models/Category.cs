using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category
    {
        public int ID { get; set; }
      
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
