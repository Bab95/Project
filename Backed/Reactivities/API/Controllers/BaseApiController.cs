using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // "[controller]" placeholder for controllers....
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.
                                                                    GetService<IMediator>();
    }
}
