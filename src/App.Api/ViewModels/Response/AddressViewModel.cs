using static App.Api.Const.DataAnnotationMessageConst;
using System.ComponentModel.DataAnnotations;

namespace App.Api.ViewModels.Response
{
    public record AddressViewModel
    {
        public Guid Id { get; init; }
        public Guid SupplierId { get; init; }
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(200, ErrorMessage = StringLengthFieldMessage, MinimumLength = 2)]
        public string? Street { get; init; }
        
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(50, ErrorMessage = StringLengthFieldMessage, MinimumLength = 1)]
        public string? Number { get; init; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(8, ErrorMessage = StringLengthFieldMessage, MinimumLength = 8)]
        public string? ZipCode { get; init; }

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(100, ErrorMessage = StringLengthFieldMessage, MinimumLength = 2)]
        public string? Neighborhood { get; init; }
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(100, ErrorMessage = StringLengthFieldMessage, MinimumLength = 2)]
        public string? City { get; init; }
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(50, ErrorMessage = StringLengthFieldMessage, MinimumLength = 2)]
        public string? State { get; init; }

        public string? Complement { get; init; }
    }
}
