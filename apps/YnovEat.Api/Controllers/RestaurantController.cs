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
            IConfiguration configuration,
            IRestaurantService restaurantService
        ) : base(userManager, configuration)
        {
            _restaurantService = restaurantService;
        }

        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] RestaurantCreationDto model)
        {
            var currentUser = await GetAuthenticatedUser();
            try
            {
                await _restaurantService.Create(model, currentUser);
                return NoContent();
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
