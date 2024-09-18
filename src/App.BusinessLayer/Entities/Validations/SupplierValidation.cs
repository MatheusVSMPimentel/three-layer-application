using App.BusinessLayer.Entities.Validations.Document;
using App.BusinessLayer.Enums;
using FluentValidation;
using static App.BusinessLayer.Const.ValidationConstMessages;

namespace App.BusinessLayer.Entities.Validations
{
    internal class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(c => c.Name)
        .NotEmpty().WithMessage(NotEmptyMessage)
        .Length(2, 100).WithMessage(LengthMessage)
        ;
            When(f => f.SupplierType == SupplierType.PrivateIndividual, () =>
            {
                RuleFor(f => f.Document.Length).Equal(CpfValidation.Size).WithMessage(DocumentLenghtEqualMessage);
                RuleFor(f =>  f.Document).Must(f=> CpfValidation.Validate(f)).WithMessage(InvalidFieldMessage);

            });
            When(f => f.SupplierType == SupplierType.PrivateIndividual, () =>
            {
                RuleFor(f => f.Document.Length).Equal(CnpjValidation.Size)
                .WithMessage(DocumentLenghtEqualMessage);
                RuleFor(f => f.Document).Must(f => CpfValidation.Validate(f)).WithMessage(InvalidFieldMessage);
            });

        }
    }
}
