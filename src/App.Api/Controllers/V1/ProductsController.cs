using App.Api.ViewModels.Response;
using App.BusinessLayer.Entities;
using App.BusinessLayer.Interfaces.Repositories;
using App.BusinessLayer.Interfaces.Services;
using App.BusinessLayer.Notifications;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController(IMapper mapper, IProductRepository productRepository, IProductService productService, INotifier notifier) : MainController(mapper, notifier)
    {

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll() => _mapper.Map<IEnumerable<ProductViewModel>>(await productRepository.GetAllProductsSupplier());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel?>> GetById(Guid id)
        {
            var product = await GetProduct(id);

            return product is null ? NotFound("Product not found.") : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel?>> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var productToUpdate = await GetProduct(productViewModel.Id);

            if (productToUpdate is not null)
            {
                NotifyError("Existent product with this Id.");
                return CustomResponse();
            }
            await productService.Add(_mapper.Map<Product>(productViewModel));

            return CustomResponse(HttpStatusCode.Created, productViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {
            if (!id.Equals(productViewModel.Id))
            {
                NotifyError("Product id is not equal to id informed into url path.");
                return CustomResponse();
            }
            var productToUpdate = await GetProduct(id);

            if (productToUpdate is null)
            {
                NotifyError("Non-existent product.");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await productService.Update(_mapper.Map<Product>(
                    productToUpdate.UpdateViewModel(productViewModel)
                    ));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel?>> Remove(Guid id)
        {
            var product = await GetProduct(id);

            if (product is null)
            {
                NotifyError("Non-existent product.");
                return CustomResponse();
            }

            await productService.Delete(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<ProductViewModel> GetProduct(Guid id) => _mapper.Map<ProductViewModel>(await productRepository.GetProductSupplierById(id));
    }
}
