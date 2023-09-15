using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UM.Api.Controllers.Shared
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HMSBaseController : ControllerBase
    {
        IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
