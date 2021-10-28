using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YLunch.Api.Core;
using YLunch.Application.Exceptions;
using YLunch.Domain.DTO.OrderModels;
using YLunch.Domain.DTO.OrderModels.OrderStatusModels;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.OrderServices;

namespace YLunch.Api.Controllers
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
            try
            {
                var currentUser = await GetAuthenticatedUser();
                var orderReadDto = await _orderService.Create(orderCreationDto, currentUser.Customer);
                return Ok(orderReadDto);
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
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

        [HttpGet("get-new-orders-ids")]
        [Authorize(Roles = UserRoles.RestaurantAdmin + "," + UserRoles.Employee)]
        public async Task<IActionResult> GetNewOrdersIds()
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                var orderReadDtoCollection =
                    await _orderService.GetNewOrdersByRestaurantId(currentUser.RestaurantUser.RestaurantId);
                return Ok(orderReadDtoCollection
                    .Select(x => x.Id)
                    .ToList());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
