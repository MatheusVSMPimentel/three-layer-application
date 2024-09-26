using App.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using static App.DataLayer.Const.TypeConstants;

namespace App.DataLayer.Context
{
    public class MsSQLServerContext(DbContextOptions<MsSQLServerContext> options)  : DbContext(options) 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(x => x.ClrType == typeof(string))).ToList()
                .ForEach(property => property.SetColumnType(SetVarchar(1000)));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsSQLServerContext).Assembly);

            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()).ToList().ForEach(relationship => relationship.DeleteBehavior = DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
