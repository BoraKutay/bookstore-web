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
    public class EfMusicCDRepository : EfEntityRepositoryBase<MusicCD>, IMusicCDRepository
    {
        public EfMusicCDRepository(DbContext cntx) : base(cntx)
        {

        }

        public async Task<MusicCD> GetById(int musicId)
        {
            return await BookstoreWebContext.MusicCDs.SingleOrDefaultAsync(mc => mc.Id == musicId);
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
