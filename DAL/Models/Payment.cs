using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Payment
    {
        public int ID { get; set; }
        [Required]
        [MinLength(16), MaxLength(16)]
        public string cardName { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{​​​​​​​0:yyyy/MM/dd}​​​​​​​", ApplyFormatInEditMode = true)]

        public DateTime PaymentDate { get; set; }

        [Required]
        public string cardOwnerNAme { get; set; }

        [ForeignKey("Users")]
        public string userID { get; set; }
        public virtual ApplicationUser Users { get; set; }
    }
}
