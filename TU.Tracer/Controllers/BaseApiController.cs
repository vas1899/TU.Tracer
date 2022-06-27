using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application.Core;

namespace TU.Tracer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) {
                return NotFound();
            }
            if (result.IsSuccess) {
                if (result.Value == null) {
                    NotFound();
                }
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
    }
}
