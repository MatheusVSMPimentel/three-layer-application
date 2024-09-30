using App.BusinessLayer.Notifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class MainController(IMapper mapper, INotifier notifier) : ControllerBase
    {
        protected readonly IMapper _mapper = mapper;

        protected bool ValidOperation() => !notifier.HasNotification();
        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object? result = null) => ValidOperation()? new ObjectResult(result) { StatusCode = Convert.ToInt32(statusCode) } : BadRequest(new {errors = notifier.GetNotifications().Select(n => n.Message)});
        protected ActionResult CustomResponse(ModelStateDictionary modelState ) => modelState.IsValid? CustomResponse() : ModelStateErrors(modelState);
        protected ActionResult ModelStateErrors(ModelStateDictionary modelState ) { NotifyModelStateErrors(modelState); return CustomResponse(); }
        protected void NotifyModelStateErrors(ModelStateDictionary modelState ) => modelState.Values.SelectMany(e => e.Errors).ToList().ForEach(e => NotifyError(e.Exception?.Message ?? e.ErrorMessage));
        protected void NotifyError(string message) => notifier.Handle(message);


    }
}
