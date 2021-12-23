using bookstore.Models;
using BookstoreWeb.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Dtos
{
    public class BookListDto : DtoGetBase
    {
        public IList<Book> Books { get; set; }
    }
}
