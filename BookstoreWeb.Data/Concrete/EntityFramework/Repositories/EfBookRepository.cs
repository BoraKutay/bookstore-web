using bookstore.Models;
using BookstoreWeb.Data.Abstract;
using BookstoreWeb.Data.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Concrete.EntityFramework.Repositories
{
    public class EfBookRepository : EfEntityRepositoryBase<Book>, IBookRepository
    {
        public EfBookRepository(DbContext cntx) : base(cntx)
        {

        }

        public async Task<Book> GetById(int bookId)
        {
            return await BookstoreWebContext.Books.SingleOrDefaultAsync(b => b.Id == bookId);
        }

        private BookstoreWebContext BookstoreWebContext
        {
            get
            {
                return _context as BookstoreWebContext;
            }
        }
    }
}
