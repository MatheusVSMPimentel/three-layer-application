using App.BusinessLayer.Entities;

namespace App.BusinessLayer.Interfaces.Services
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}
