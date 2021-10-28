using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YLunch.Api.Core;
using YLunch.Application.Exceptions;
using YLunch.Domain.DTO.RestaurantModels;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.RestaurantServices;
using YLunch.Domain.Services.UserServices;

namespace YLunch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : CustomControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserService _userService;

        public RestaurantController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRestaurantService restaurantService,
            IRestaurantRepository restaurantRepository,
            IUserService userService
        ) : base(userManager, userRepository, configuration)
        {
            _restaurantService = restaurantService;
            _restaurantRepository = restaurantRepository;
            _userService = userService;
        }

        [HttpPost("create")]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Create([FromBody] RestaurantCreationDto model)
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                if (currentUser.HasARestaurant)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User has already a restaurant"
                    );
                return Ok(await _restaurantService.Create(model, currentUser));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [HttpPatch("update")]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Update([FromBody] RestaurantModificationDto model)
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                var restaurant = await _restaurantRepository.GetByIdIncludingProducts(model.Id);

                if (restaurant == null)
                    return StatusCode(
                        StatusCodes.Status404NotFound,
                        "Restaurant not found"
                    );

                if (!restaurant.RestaurantUsers.Any(x => x.UserId.Equals(currentUser.Id)))
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User is not from the restaurant"
                    );

                return Ok(await _restaurantService.Update(model, restaurant));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [HttpGet("get-mine")]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                return Ok(await _restaurantService.GetByUserId(currentUser.Id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [HttpGet("get-customer-details/{customerId}")]
        [Authorize(Roles = UserRoles.RestaurantAdmin + "," + UserRoles.Employee)]
        public async Task<IActionResult> GetCustomerDetails(string customerId)
        {
            try
            {
                var customer = await _userService.GetAsCustomerById(customerId);
                return Ok(customer);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [HttpGet("get-today-orders")]
        [Authorize(Roles = UserRoles.RestaurantAdmin + "," + UserRoles.Employee)]
        public async Task<IActionResult> GetTodayOrders()
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                var orderReadDtoCollection = await _restaurantService.GetTodayOrders(currentUser.RestaurantUser.RestaurantId);
                return Ok(orderReadDtoCollection);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }
    }
}
