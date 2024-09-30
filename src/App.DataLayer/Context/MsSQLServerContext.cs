using App.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using static App.DataLayer.Const.TypeConstants;

namespace App.DataLayer.Context
{
    public class MsSQLServerContext : DbContext
    {
        
        public MsSQLServerContext(DbContextOptions<MsSQLServerContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(x => x.ClrType == typeof(string))).ToList()
                .ForEach(property => property.SetColumnType(SetVarchar(1000)));
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(x => x.ClrType == typeof(decimal))).ToList()
                .ForEach(property => property.SetColumnType(DecimalType));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsSQLServerContext).Assembly);

            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()).ToList().ForEach(relationship => relationship.DeleteBehavior = DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default ) {

            ChangeTracker.Entries().Where(entry => 
            entry.Entity.GetType().GetProperty(nameof(Product.RegisterDate)) != null ||
            entry.Entity.GetType().GetProperty(nameof(Entity.CreatedAt)) != null ||
            entry.Entity.GetType().GetProperty(nameof(Entity.UpdateAt)) != null
            ).ToList().ForEach(entry =>
            {
                if(entry.State == EntityState.Added)
                {
                    if(entry.Entity.GetType() == typeof(Product))
                    {
                        entry.Property(nameof(Product.RegisterDate)).CurrentValue = DateTime.UtcNow;
                    }
                    entry.Property(nameof(Entity.CreatedAt)).CurrentValue = DateTime.UtcNow;
                    entry.Property(nameof(Entity.UpdateAt)).CurrentValue = DateTime.UtcNow;
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(Product.RegisterDate)).IsModified = false;
                    entry.Property(nameof(Entity.CreatedAt)).IsModified = false;
                    entry.Property(nameof(Entity.UpdateAt)).CurrentValue = DateTime.UtcNow;
                }
            });
            
            return base.SaveChangesAsync(cancellationToken); 
        }
    }
}
