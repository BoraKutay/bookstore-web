using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookstoreWeb.Entities.Abstract;
using BookstoreWeb.Shared.Entities.Abstract;

namespace bookstore.Models
{


    public class Book : ProductBase, IEntity
    {

        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Page { get; set; }



    }
}
