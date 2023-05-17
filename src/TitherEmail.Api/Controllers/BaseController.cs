using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace TitherEmail.Api.Controllers
{
    public partial class TitherEmailControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitherEmailControllerBase(IMediator mediator)
            => _mediator = mediator;

        protected async Task<IActionResult> SendRequest<T>(IRequest<Result<T>> request)
            => await _mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, var result, _) => Ok(result),
                (_, _, var error) => HandleError(new Exception(error?.Message))
            };

        protected async Task<IActionResult> SendRequest(IRequest<Result> request, int statusCode = 200)
            => await _mediator.Send(request).ConfigureAwait(false) switch
            {
                (true, _) => StatusCode(statusCode),
                (_, var error) => HandleError(error)
            };

        private IActionResult HandleError(Exception error)
            => error switch
            {
                Exception e => BadRequest(e.Message),
                _ => BadRequest(new Exception(error.Message))
            };
    }
}
