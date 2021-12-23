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
    public class EfMagazineRepository : EfEntityRepositoryBase<Magazine>, IMagazineRepository
    {
        public EfMagazineRepository(DbContext cntx) : base(cntx)
        {

        }

        public async Task<Magazine> GetById(int magazineId)
        {
            return await BookstoreWebContext.Magazines.SingleOrDefaultAsync(m => m.Id == magazineId);
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
