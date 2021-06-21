using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Api.Core;
using YnovEat.Domain.DTO.ProductModels.RestaurantProductModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.RestaurantServices;

namespace YnovEat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantProductController : CustomControllerBase
    {
        private readonly IRestaurantProductService _restaurantProductService;
        private readonly IRestaurantProductRepository _restaurantProductRepository;

        public RestaurantProductController(
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

        [HttpPost]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Create([FromBody] RestaurantProductCreationDto model)
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                if (!currentUser.HasARestaurant)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User has not a restaurant"
                    );
                return Ok(await _restaurantProductService.Create(model, currentUser.RestaurantUser.RestaurantId));
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Update([FromBody] RestaurantProductModificationDto model)
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                if (!currentUser.HasARestaurant)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User has not a restaurant"
                    );

                var existingProducts = await _restaurantProductRepository.GetAllByRestaurantId(currentUser.RestaurantUser.RestaurantId);

                var restaurantProductToUpdate =
                    existingProducts.FirstOrDefault(x => x.Id.Equals(model.Id));

                if (restaurantProductToUpdate == null)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "Product not found"
                    );

                return Ok(await _restaurantProductService.Update(model, restaurantProductToUpdate));
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [HttpGet("get-all")]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                if (!currentUser.HasARestaurant)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User has not a restaurant"
                    );

                var restaurantProducts =
                    await _restaurantProductService.GetAllByRestaurantId(currentUser.RestaurantUser.RestaurantId);

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

        [HttpGet("{productId}")]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Get(string productId)
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                if (!currentUser.HasARestaurant)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User has not a restaurant"
                    );

                var restaurantProducts =
                    await _restaurantProductService.GetAllByRestaurantId(currentUser.RestaurantUser.RestaurantId);

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

        [HttpDelete("{productId}")]
        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        public async Task<IActionResult> Delete(string productId)
        {
            try
            {
                var currentUser = await GetAuthenticatedUser();
                if (!currentUser.HasARestaurant)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "User has not a restaurant"
                    );

                var restaurantProducts =
                    await _restaurantProductService.GetAllByRestaurantId(currentUser.RestaurantUser.RestaurantId);

                var restaurantProduct =
                    restaurantProducts.FirstOrDefault(x => x.Id.Equals(productId));

                if (restaurantProduct == null)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "Product not found"
                    );

                await _restaurantProductService.Delete(productId);

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
