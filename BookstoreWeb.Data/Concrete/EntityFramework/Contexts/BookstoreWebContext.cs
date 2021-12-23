using bookstore.Models;
using BookstoreWeb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Concrete.EntityFramework.Contexts
{
    public class BookstoreWebContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<MusicCD> MusicCDs { get; set; }
        public DbSet<CustomerBase> CustomerBases { get; set; }

        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\DESKTOP-2BE6DAO\\SQLEXPRESS; Database=BookstoreDB Integrated Security=true");
        }
    }


}
