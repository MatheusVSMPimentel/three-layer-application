using App.BusinessLayer.Entities;

namespace App.BusinessLayer.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}
