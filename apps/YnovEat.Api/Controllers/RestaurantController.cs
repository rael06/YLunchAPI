using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Api.Core;
using YnovEat.Api.Core.Response.Errors;
using YnovEat.Domain.DTO.RestaurantModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : CustomControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRestaurantService restaurantService
        ) : base(userManager, userRepository, configuration)
        {
            _restaurantService = restaurantService;
        }

        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] RestaurantCreationDto model)
        {
            var currentUser = await GetAuthenticatedUser();
            if (currentUser.HasARestaurant)
                return StatusCode(
                    StatusCodes.Status403Forbidden,
                    "User has already a restaurant"
                );

            try
            {
                return Ok(await _restaurantService.Create(model, currentUser));
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
