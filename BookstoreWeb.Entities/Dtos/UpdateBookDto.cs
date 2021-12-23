using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Dtos
{
    public class UpdateBookDto
    {
        [Required]
        public int Id { get; set; }

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

        [DisplayName("Isbn")]
        [StringLength(13, ErrorMessage = "More than {1} characters should NOT be entered.")]
        public string Isbn { get; set; }

        [DisplayName("Author Name")]
        [StringLength(50, ErrorMessage = "More than {1} characters should NOT be entered.")]
        public string Author { get; set; }

        [DisplayName("Publisher")]
        public string Publisher { get; set; }

        [DisplayName("Number of Page")]
        public int Page { get; set; }
    }
}
