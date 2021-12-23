using BookstoreWeb.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookstore.Models;

namespace BookstoreWeb.Data.Abstract
{
    public interface IBookRepository : IEntityRepository<Book>
    {
        Task<Book> GetById(int bookId);
    }
}
