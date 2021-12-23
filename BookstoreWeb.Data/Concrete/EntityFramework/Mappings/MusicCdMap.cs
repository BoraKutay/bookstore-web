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
    public class MusicCdMap : IEntityTypeConfiguration<MusicCD>
    {
        public void Configure(EntityTypeBuilder<MusicCD> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Name).IsRequired();

            builder.Property(m => m.Price).IsRequired();

            builder.Property(m => m.Picture).IsRequired();

            builder.Property(m => m.Issue).IsRequired();

            builder.Property(m => m.Singer);

            builder.Property(m => m.Demo);

            builder.Property(m => m.CreatedByName).IsRequired();
            builder.Property(m => m.CreatedByName).HasMaxLength(50);

            builder.Property(m => m.ModifiedByName).IsRequired();
            builder.Property(m => m.ModifiedByName).HasMaxLength(50);

            builder.Property(m => m.CreatedTime).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();

            builder.Property(m => m.IsActive).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();
        }
    }
}
