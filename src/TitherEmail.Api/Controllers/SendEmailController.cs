using MediatR;
using Microsoft.AspNetCore.Mvc;
using TitherEmail.Shared.Requests;

namespace TitherEmail.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : TitherEmailControllerBase
    {
        public SendEmailController(IMediator mediator)
            : base(mediator) { }

        [HttpPost]
        public Task<IActionResult> Send([FromBody] SendEmailRequest request)
         => SendRequest(request);
    }
}
