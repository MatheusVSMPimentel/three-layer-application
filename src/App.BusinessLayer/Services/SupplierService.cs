using App.BusinessLayer.Entities;
using App.BusinessLayer.Entities.Validations;
using App.BusinessLayer.Interfaces.Repositories;
using App.BusinessLayer.Interfaces.Services;
using App.BusinessLayer.Notifications;

namespace App.BusinessLayer.Services
{
    public class SupplierService(ISupplierRepository supplierRepository, INotifier notifier) : BaseService(notifier), ISupplierService
    {
        public async Task Add(Supplier supplier)
        {
            //TODO: Validation consistent entity?
            //TODO: Validation Supplier has unique Document?
            if (!ExecValidator(new SupplierValidation(), supplier) || !ExecValidator(new AddressValidation(), supplier?.Address)) return;
            if (supplierRepository.SearchFunction(f => f.Document == supplier.Document).Result.Any())
            {
                Notify("Supplier Document already recorded in database.");
                return;
            }
            await supplierRepository.Add(supplier);

        }

        public async Task Update(Supplier supplier)
        {
            if (supplierRepository.SearchFunction(f => f.Document == supplier.Document && f.Id == supplier.Id).Result.Any())
            {
                Notify("Supplier Document already recorded in database.");
                return;
            }
            await supplierRepository.Update(supplier);
        }
        public async Task Delete(Guid id)
        {
            var supplier = await supplierRepository.GetSupllierProductsAndAdress(id);
            if (supplier == null)
            {
                Notify("Supplier not existent in database records.");
                return;
            }
            if (supplier?.Products?.Count > 0)
            {
                Notify("Supplier still have products related to him.");
                return;
            }
            var address = await supplierRepository.GetSupplierAddress(id);
            if (address != null)
            {
                await supplierRepository.RemoveSupplierAddress(address);
            }
            await supplierRepository.Delete(id);
        }

        public void Dispose()
        {
            supplierRepository?.Dispose();
        }
    }
}
