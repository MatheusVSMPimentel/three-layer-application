using App.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static App.DataLayer.Const.TypeConstants;
namespace App.DataLayer.Mappings
{
    internal class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasColumnType(SetVarchar(200));
            builder.Property(x => x.Document).IsRequired().HasColumnType(SetVarchar(14));

            builder.HasOne(x => x.Address).WithOne(x => x.Supplier);
            builder.HasMany(x => x.Products).WithOne(x => x.Supplier).HasForeignKey(s => s.SupplierId);

            builder.ToTable($"{nameof(Supplier)}s");
        }
    }
}
