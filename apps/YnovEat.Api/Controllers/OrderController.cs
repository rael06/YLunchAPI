using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Api.Core;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.OrderServices;

namespace YnovEat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : CustomControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IOrderService orderService
        ) : base(userManager, userRepository, configuration)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        [Authorize(Roles = UserRoles.Customer)]
        public async Task<IActionResult> Create([FromBody] OrderCreationDto orderCreationDto)
        {
            var currentUser = await GetAuthenticatedUser();
            var order = await _orderService.Create(orderCreationDto, currentUser.Customer);
            return Ok("order create");
        }
    }
}
