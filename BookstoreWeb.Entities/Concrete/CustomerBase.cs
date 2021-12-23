using BookstoreWeb.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Concrete
{
    public class CustomerBase : IEntity
    {
        [Key]
        public int CustomerID { get; set; }
        public bool IsAdmin { get ; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerPassword { get; set; }
        public bool AdminConfirm { get; set; }
    }
}
