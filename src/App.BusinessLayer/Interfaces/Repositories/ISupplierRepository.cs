using App.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessLayer.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier?> GetSupllierAndAdress(Guid supplierId);
        Task<Supplier?> GetSupllierProductsAndAdress(Guid supplierId);
        Task<Address?> GetSupplierAddress(Guid supplierId);
        Task RemoveSupplierAddress(Address address);
    }
}
