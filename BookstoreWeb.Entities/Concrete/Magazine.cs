using BookstoreWeb.Entities.Abstract;
using BookstoreWeb.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public enum MagazineType
    {
        Science,
        News,
        Sport,
        Computer,
        Technology,
    }

    public class Magazine : ProductBase, IEntity
    {

        public MagazineType Type { get; set; }
    }
}
