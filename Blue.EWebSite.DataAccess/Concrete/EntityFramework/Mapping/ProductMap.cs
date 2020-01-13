using Blue.EWebSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blue.EWebSite.DataAccess.Concrete.EntityFramework.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired();
            builder.Property(c => c.StockQuantity).IsRequired();
            builder.Property(c => c.UnitPrice).IsRequired();
        }
    }
}
