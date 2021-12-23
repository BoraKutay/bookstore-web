using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Dtos
{
    public class AddMagazineDto
    {
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Name { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "{0} field is required.")]
        public double Price { get; set; }

        [DisplayName("Picture")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Picture { get; set; }

        [DisplayName("Issue")]
        [Required(ErrorMessage = "{0} field is required.")]
        public string Issue { get; set; }


    }
}
