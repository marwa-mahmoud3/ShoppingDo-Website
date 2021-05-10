using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
    public class RegisterViewModel
    {

        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        public string Gender { get; set; }

        public string Country { get; set; }

        [MinLength(6)]
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("PasswordHash")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public bool isDeleted { get; set; }
    }
}

