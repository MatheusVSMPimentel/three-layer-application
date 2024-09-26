using App.BusinessLayer.Entities;
using App.BusinessLayer.Entities.Validations;
using App.BusinessLayer.Interfaces.Repositories;
using App.BusinessLayer.Interfaces.Services;
using App.BusinessLayer.Notifications;

namespace App.BusinessLayer.Services
{
    public class ProductService(IProductRepository productRepository, INotifier notifier) : BaseService(notifier), IProductService
    {
        public async Task Add(Product product)
        {
            if (!ExecValidator(new ProductValidation(), product)) return;
            await productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            await productRepository.Update(product);
        }
        public async Task Delete(Guid id)
        {
            await productRepository.Delete(id);
        }

        public void Dispose()
        {
            productRepository?.Dispose();
        }
    }
}
