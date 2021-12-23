using BookstoreWeb.Entities.Abstract;
using BookstoreWeb.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public enum MusicCDType
    {
        Rap,
        Rock,
        Pop,
        Metal,
    }
    public class MusicCD : ProductBase, IEntity
    {

        public string Singer { get; set; }
        public MusicCDType Type { get; set; }
        public string Demo { get; set; }
    }
}
