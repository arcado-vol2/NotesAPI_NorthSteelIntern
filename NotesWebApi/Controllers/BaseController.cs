using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace NotesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    _mediator = HttpContext.RequestServices.GetService<IMediator>();
                }
                return _mediator;
            }
        }

        internal Guid UserID
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Guid.Empty;
                }
                else
                {
                    return Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
            }
        }
    }
}
