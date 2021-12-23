using BookstoreWeb.Entities.Concrete;
using BookstoreWeb.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Abstract
{
    public interface ICustomerRepository : IEntityRepository<CustomerBase>
    {
        Task<CustomerBase> GetById(int customerId);
    }
}
