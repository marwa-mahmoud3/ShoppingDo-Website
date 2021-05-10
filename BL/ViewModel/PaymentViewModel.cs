using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class PaymentViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(16), MaxLength(16)]
        public string cardNumber { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{​​​​​​​0:yyyy/MM/dd}​​​​​​​", ApplyFormatInEditMode = true)]

        public DateTime PaymentDate { get; set; }

        [Required]
        public string cardOwnerNAme { get; set; }

        public string userID { get; set; }
    }
}
