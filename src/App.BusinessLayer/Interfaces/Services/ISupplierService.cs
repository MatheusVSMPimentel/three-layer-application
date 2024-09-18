using App.BusinessLayer.Entities;

namespace App.BusinessLayer.Interfaces.Services
{
    public interface ISupplierService : IDisposable
    {
        Task Add(Supplier supplier);
        Task Update(Supplier supplier);
        Task Delete(Guid id);
    }
}
