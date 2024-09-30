using App.BusinessLayer.Entities;
using App.BusinessLayer.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace App.BusinessLayer.Services
{
    public abstract class BaseService(INotifier notifier)
    {
        private readonly INotifier _notifier = notifier;   
        protected void Notify(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e =>
            {
                Notify(e.ErrorMessage);
            });
        }

        protected void Notify(string message)
        {
            _notifier.Handle(message);
        }

        protected bool ExecValidator<TValidator, TEntity>(TValidator validator, TEntity entity) 
            where TValidator : AbstractValidator<TEntity> 
            where TEntity : Entity
        {
            var validatorResult = validator.Validate(entity);
            if (!validatorResult.IsValid) Notify(validatorResult);

            return validatorResult.IsValid;
        }
    }
}
