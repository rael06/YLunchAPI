using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Api.Core;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.DTO.OrderModels;
using YnovEat.Domain.DTO.OrderModels.OrderStatusModels;
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
            var orderReadDto = await _orderService.Create(orderCreationDto, currentUser.Customer);
            return Ok(orderReadDto);
        }

        [HttpPost("add-status")]
        [Authorize(Roles = UserRoles.RestaurantAdmin + "," + UserRoles.Employee)]
        public async Task<IActionResult> AddStatus([FromBody] OrderStatusCreationDto orderStatusCreationDto)
        {
            var orderReadDto = await _orderService.AddStatus(orderStatusCreationDto);
            return Ok(orderReadDto);
        }

        [HttpPost("add-status-to-orders")]
        [Authorize(Roles = UserRoles.RestaurantAdmin + "," + UserRoles.Employee)]
        public async Task<IActionResult> AddStatusToMultipleOrders(
            [FromBody] AddOrderStatusToMultipleOrdersDto addOrderStatusToMultipleOrdersDto)
        {
            try
            {
                var orderReadDtoCollection =
                    await _orderService.AddStatusToMultipleOrders(addOrderStatusToMultipleOrdersDto);
                return Ok(orderReadDtoCollection);
            }
            catch (BadNewOrderStateException e)
            {
                return StatusCode(StatusCodes.Status403Forbidden, e.Message);
            }
            catch (Exception e1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e1.Message);
            }
        }
    }
}
