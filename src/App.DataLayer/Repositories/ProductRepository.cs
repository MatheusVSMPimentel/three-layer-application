using App.BusinessLayer.Entities;
using App.BusinessLayer.Interfaces.Repositories;
using App.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace App.DataLayer.Repositories
{
    public class ProductRepository(MsSQLServerContext msSQLServerContext) : Repository<Product>(msSQLServerContext), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetAllProductsSupplier()
        {
            return await DbSet.AsNoTracking().Include(p => p.Supplier).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product?> GetProductSupplierById(Guid productId)
        {
            return await DbSet.AsNoTracking().Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id.Equals(productId));
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await SearchFunction(p => p.SupplierId.Equals(supplierId));
        }
    }
}
