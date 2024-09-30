using static App.Api.Const.DataAnnotationMessageConst;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace App.Api.ViewModels.Response
{
    public record SupplierViewModel
    {
        public Guid Id { get; init; }
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(100, ErrorMessage = StringLengthFieldMessage, MinimumLength = 2)]
        public string? Name { get; init; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(14, ErrorMessage = StringLengthFieldMessage, MinimumLength = 11)]
        public string? Document { get; init; }
        public int SupplierType { get; init; }
        public bool Active { get; init; }
        public AddressViewModel? Address { get; init; }
        public IEnumerable<AddressViewModel>? Products { get; init; }

    }
}
