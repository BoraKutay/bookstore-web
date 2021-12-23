using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Dtos
{
    public class UpdateCustomerDto
    {

        [Required]
        public int Id { get; set; }

        [DisplayName("Is Admin?")]
        public bool IsAdmin { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        [StringLength(50, ErrorMessage = "More than {1} characters should NOT be entered.")]
        public string CustomerName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        public string CustomerAddress { get; set; }


        [DisplayName("Mail")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}")]
        public string CustomerMail { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        public string CustomerUsername { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} can't be empty.")]
        public string CustomerPassword { get; set; }

        [DisplayName("Confirmation")]
        public bool AdminConfirm { get; set; }
    }
}
