using bookstore.Models;
using BookstoreWeb.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Entities.Dtos
{
    public class MusicCdDto : DtoGetBase
    {
        public MusicCD MusicCD { get; set; }
    }
}
