using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Core.Authorize(Roles = UserRoles.Customer)]
    public class CustomerProductController : CustomControllerBase
    {
        private readonly IRestaurantProductService _restaurantProductService;
        private readonly IRestaurantProductRepository _restaurantProductRepository;

        public CustomerProductController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRestaurantProductService restaurantProductService,
            IRestaurantProductRepository restaurantProductRepository
        ) : base(userManager, userRepository, configuration)
        {
            _restaurantProductService = restaurantProductService;
            _restaurantProductRepository = restaurantProductRepository;
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
