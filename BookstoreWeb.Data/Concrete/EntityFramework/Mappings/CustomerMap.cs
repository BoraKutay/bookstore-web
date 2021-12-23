using BookstoreWeb.Entities.Abstract;
using BookstoreWeb.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Data.Concrete.EntityFramework.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<CustomerBase>
    {
        public void Configure(EntityTypeBuilder<CustomerBase> builder)
        {
            builder.HasKey(c => c.CustomerID);
            builder.Property(c => c.CustomerID).ValueGeneratedOnAdd();

            builder.Property(c => c.CustomerName).IsRequired();
            builder.Property(c => c.CustomerName).HasMaxLength(50);

            builder.Property(c => c.CustomerMail).IsRequired();

            builder.Property(c => c.CustomerPassword).IsRequired();

            builder.Property(c => c.CustomerUsername).IsRequired();

            builder.Property(c => c.IsAdmin);

            builder.Property(c => c.AdminConfirm);
        }
    }
}
