using static App.Api.Const.DataAnnotationMessageConst;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.Api.ViewModels.Response
{
    public record ProductViewModel
    {
        public Guid Id { get; init; }
        [Required(ErrorMessage = RequiredFieldMessage)]
        public Guid SupplierId { get; init; }
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(200, ErrorMessage = StringLengthFieldMessage, MinimumLength =2)]
        public string? Name { get; init; }
        
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(1000, ErrorMessage = StringLengthFieldMessage, MinimumLength =2)]
        public string? Description { get; init; }
        
        [Required(ErrorMessage = RequiredFieldMessage)]
        public decimal Value { get; init; }
        public DateTime RegisteredAt { get; init; }
        public bool Active { get; init; }
        public string? SupplierName { get; init; }

        public ProductViewModel UpdateViewModel(ProductViewModel productViewModel) => this with
        {
            //SupplierId = productViewModel.SupplierId,
            Name = productViewModel.Name,
                Description = productViewModel.Description,
                Value = productViewModel.Value,
                Active = productViewModel.Active,
            };
    }
}
