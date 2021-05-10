using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Brands
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }

        [InverseProperty("brand")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
