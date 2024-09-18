using FluentValidation;
using static App.BusinessLayer.Const.ValidationConstMessages;

namespace App.BusinessLayer.Entities.Validations
{
    internal class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 200).WithMessage(LengthMessage);
            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 100).WithMessage(LengthMessage);
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(8,8).WithMessage(LengthMessage);
            RuleFor(c => c.City)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 100).WithMessage(LengthMessage);
            RuleFor(c => c.State)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 50).WithMessage(LengthMessage);
            RuleFor(c => c.Number)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 50).WithMessage(LengthMessage);
        }
    }
}
