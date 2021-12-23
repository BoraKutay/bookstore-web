using BookstoreWeb.Data.Abstract;
using BookstoreWeb.Data.Concrete.EntityFramework.Contexts;
using BookstoreWeb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Concrete.EntityFramework.Repositories
{
    public class EfCustomerRepository :EfEntityRepositoryBase<CustomerBase>, ICustomerRepository
    {

        public EfCustomerRepository(DbContext cntx) : base(cntx)
        {

        }

        public async Task<CustomerBase> GetById(int customerId)
        {
            return await BookstoreWebContext.CustomerBases.SingleOrDefaultAsync(c => c.CustomerID == customerId);
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
