using App.BusinessLayer.Enums;

namespace App.BusinessLayer.Entities
{

    public record Supplier : Entity
    {
        public string? Name { get; set; }
        public string? Document { get; set; }
        public bool Active { get; set; }
        public SupplierType SupplierType { get; set; }
        public Address? Address { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
