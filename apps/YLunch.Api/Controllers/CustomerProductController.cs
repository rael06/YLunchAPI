using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.RestaurantServices;

namespace YLunch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Core.Authorize(Roles = UserRoles.Customer)]
    public class CustomerProductController : CustomControllerBase
    {
        private readonly IRestaurantProductService _restaurantProductService;

        public CustomerProductController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRestaurantProductService restaurantProductService
        ) : base(userManager, userRepository, configuration)
        {
            _restaurantProductService = restaurantProductService;
        }


        [AllowAnonymous]
        [HttpGet("get-all/{restaurantId}")]
        public async Task<IActionResult> GetAll(string restaurantId)
        {
            try
            {
                var restaurantProducts =
                    await _restaurantProductService.GetAllForCustomerByRestaurantId(restaurantId);

                return Ok(restaurantProducts);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [AllowAnonymous]
        [HttpGet("{restaurantId}/{productId}")]
        public async Task<IActionResult> Get(string restaurantId, string productId)
        {
            try
            {
                var restaurantProducts =
                    await _restaurantProductService.GetAllByRestaurantId(restaurantId);

                var restaurantProduct =
                    restaurantProducts.FirstOrDefault(x => x.Id.Equals(productId));

                if (restaurantProduct == null)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "Product not found"
                    );

                return Ok(restaurantProduct);
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
