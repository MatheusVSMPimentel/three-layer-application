using App.BusinessLayer.Entities;
using App.BusinessLayer.Interfaces.Repositories;
using App.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace App.DataLayer.Repositories
{
    public class SupplierRepository(MsSQLServerContext msSQLServer) : Repository<Supplier>(msSQLServer), ISupplierRepository
    {
        public async Task<Supplier?> GetSupllierAndAdress(Guid supplierId)
        {
            return await Db.Suppliers.AsNoTracking().Include(s => s.Address).FirstOrDefaultAsync(s => s.Id.Equals(supplierId));
        }

        public async Task<Supplier?> GetSupllierProductsAndAdress(Guid supplierId)
        {
            return await Db.Suppliers.AsNoTracking().Include(s => s.Address).Include(s => s.Products).FirstOrDefaultAsync(s => s.Id.Equals(supplierId));
        }

        public async Task<Address?> GetSupplierAddress(Guid supplierId)
        {
            return await Db.Addresses.AsNoTracking().FirstOrDefaultAsync(s => s.SupplierId.Equals(supplierId));
        }

        public async Task RemoveSupplierAddress(Address address)
        {
            Db.Addresses.Remove(address);
            await SaveChanges();
        }
    }
}
