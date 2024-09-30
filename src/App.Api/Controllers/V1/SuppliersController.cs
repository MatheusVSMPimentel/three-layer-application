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
    public class SuppliersController(IMapper mapper, ISupplierRepository supplierRepository, ISupplierService supplierService, INotifier notifier) : MainController(mapper, notifier)
    {

        [HttpGet]
        public async Task<IEnumerable<SupplierViewModel>> GetAll() => _mapper.Map<IEnumerable<SupplierViewModel>>(await supplierRepository.GetAll());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel?>> GetById(Guid id)
        {
            var supplier = await GetSupplierProductsAndAddress(id);

            if (supplier is null) return NotFound();

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierViewModel?>> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await supplierService.Add(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(HttpStatusCode.Created, supplierViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, SupplierViewModel supplierViewModel)
        {
            if (!id.Equals(supplierViewModel.Id))
            {
                NotifyError("Product id is not equal to id informed into url path.");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await supplierService.Update(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel?>> Remove(Guid id)
        {
            await supplierService.Delete(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<SupplierViewModel> GetSupplierProductsAndAddress(Guid Id) => _mapper.Map<SupplierViewModel>(await supplierRepository.GetSupllierProductsAndAdress(Id));
    }
}
