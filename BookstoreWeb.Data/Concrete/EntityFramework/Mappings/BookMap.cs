using bookstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Concrete.EntityFramework.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).IsRequired();

            builder.Property(b => b.Price).IsRequired();

            builder.Property(b => b.Picture).IsRequired();

            builder.Property(b => b.Issue).IsRequired();

            builder.Property(b => b.Isbn).HasMaxLength(13);

            builder.Property(b => b.Author).HasMaxLength(50);

            builder.Property(b => b.Publisher);

            builder.Property(b => b.Page);

            builder.Property(b => b.CreatedByName).IsRequired();
            builder.Property(b => b.CreatedByName).HasMaxLength(50);

            builder.Property(b => b.ModifiedByName).IsRequired();
            builder.Property(b => b.ModifiedByName).HasMaxLength(50);

            builder.Property(b => b.CreatedTime).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();

            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();

        }
    }
}
