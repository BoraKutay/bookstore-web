using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBookRepository Books { get; }
        IMusicCDRepository MusicCDs { get; }
        IMagazineRepository Magazines { get; }
        ICustomerRepository CustomerBases { get; }
        Task<int> SaveAsync();
       
    }
}
