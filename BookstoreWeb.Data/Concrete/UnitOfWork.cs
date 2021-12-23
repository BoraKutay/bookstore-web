using BookstoreWeb.Data.Abstract;
using BookstoreWeb.Data.Concrete.EntityFramework.Contexts;
using BookstoreWeb.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookstoreWebContext context;
        private EfBookRepository _bookRepository;
        private EfMagazineRepository _magazineRepository;
        private EfMusicCDRepository _musicRepository;
        private EfCustomerRepository _customerRepository;


        public UnitOfWork(BookstoreWebContext context)
        {
            this.context = context;
        }

        public IBookRepository Books => _bookRepository ?? new EfBookRepository(this.context);

        public IMagazineRepository Magazines => _magazineRepository ?? new EfMagazineRepository(this.context);

        public IMusicCDRepository MusicCDs => _musicRepository ?? new EfMusicCDRepository(this.context);

        public ICustomerRepository CustomerBases => _customerRepository ?? new EfCustomerRepository(this.context);


        public async ValueTask DisposeAsync()
        {
            await this.context.DisposeAsync();
        }


        public async Task<int> SaveAsync()
        {
            return await this.context.SaveChangesAsync();
        }






    }
}
