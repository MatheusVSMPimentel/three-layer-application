using App.BusinessLayer.Entities;
using App.BusinessLayer.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected static bool ExecValidator<TValidator, TEntity>(TValidator validator, TEntity entity) 
            where TValidator : AbstractValidator<TEntity> 
            where TEntity : Entity
        {
            var validatorResult = validator.Validate(entity);
           
            return validatorResult.IsValid;
        }
    }
}
