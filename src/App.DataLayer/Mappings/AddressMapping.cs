using App.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static App.DataLayer.Const.TypeConstants;
namespace App.DataLayer.Mappings
{
    internal class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Street).IsRequired().HasColumnType(SetVarchar(200));
            builder.Property(x => x.Number).IsRequired().HasColumnType(SetVarchar(50));
            builder.Property(x => x.ZipCode).IsRequired().HasColumnType(SetVarchar(8));
            builder.Property(x => x.Complement).HasColumnType(SetVarchar(250));
            builder.Property(x => x.Neighborhood).IsRequired().HasColumnType(SetVarchar(100));
            builder.Property(x => x.City).IsRequired().HasColumnType(SetVarchar(100));
            builder.Property(x => x.City).IsRequired().HasColumnType(SetVarchar(50));

            builder.ToTable($"{nameof(Address)}es");
        }
    }
}
