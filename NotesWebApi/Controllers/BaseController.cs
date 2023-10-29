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
                    return new Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8"); //just for test in real it mast be Guid.Empty;
                }
                else
                {
                    return Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
            }
        }
    }
}
