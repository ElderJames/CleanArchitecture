using CleanArchitecture.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return result ? Ok() : BadRequest();
        }
    }
}