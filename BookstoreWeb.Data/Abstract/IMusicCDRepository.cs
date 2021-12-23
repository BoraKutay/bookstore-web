using bookstore.Models;
using BookstoreWeb.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Abstract
{
    public interface IMusicCDRepository : IEntityRepository<MusicCD>
    {
        Task<MusicCD> GetById(int musicId);
    }
}
