using FluentValidation;
using static App.BusinessLayer.Const.ValidationConstMessages;

namespace App.BusinessLayer.Entities.Validations
{
    internal class ProductValidation : AbstractValidator<Product>
    {

        public ProductValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 200).WithMessage(LengthMessage)
                ;
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage(NotEmptyMessage)
                .Length(2, 200).WithMessage(LengthMessage)
                ;
            RuleFor(c => c.Value)
                .GreaterThan(0).WithMessage(GreatThanMessage);
        }
    }
}
