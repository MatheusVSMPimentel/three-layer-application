using App.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static App.DataLayer.Const.TypeConstants;

namespace App.DataLayer.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasColumnType(SetVarchar(200));
            builder.Property(x => x.Description).IsRequired().HasColumnType(SetVarchar(1000));

            builder.ToTable($"{nameof(Product)}s");
        }
    }
}
