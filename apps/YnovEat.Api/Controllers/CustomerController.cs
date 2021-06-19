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
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : CustomControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public CustomerController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRestaurantService restaurantService
        ) : base(userManager, userRepository, configuration)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("get-all-restaurants")]
        [Authorize(Roles = UserRoles.Customer)]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
            {
                return Ok(await _restaurantService.GetAllForCustomer());
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
