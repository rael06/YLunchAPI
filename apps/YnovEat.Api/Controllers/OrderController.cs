using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Api.Core;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;

namespace YnovEat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : CustomControllerBase
    {
        public OrderController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration
        ) : base(userManager, userRepository, configuration)
        {
        }

        [HttpPost("create")]
        [Authorize(Roles = UserRoles.Customer)]
        public async Task<IActionResult> Create()
        {
            return Ok("order create");
        }
    }
}
