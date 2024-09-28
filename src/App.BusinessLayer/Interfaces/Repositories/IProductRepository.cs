using App.BusinessLayer.Entities;

namespace App.BusinessLayer.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
        Task<IEnumerable<Product>> GetAllProductsSupplier();
        Task<Product?> GetProductSupplierById(Guid productId);
    }
}
