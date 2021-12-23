using bookstore.Models;
using BookstoreWeb.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Abstract
{
    public interface IMagazineRepository : IEntityRepository<Magazine>
    {
        Task<Magazine> GetById(int magazineId);
    }
}
