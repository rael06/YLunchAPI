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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IProductService productService,
            IProductRepository productRepository
        ) : base(userManager, userRepository, configuration)
        {
            _productService = productService;
            _productRepository = productRepository;
        }

        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpPost]
        [Route("create")]
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
                return Ok(await _productService.Create(model, currentUser.RestaurantUser.RestaurantId));
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpPatch]
        [Route("update")]
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

                var existingProducts = await _productRepository.GetAllByRestaurantId(currentUser.RestaurantUser.RestaurantId);

                var restaurantProductToUpdate =
                    existingProducts.FirstOrDefault(x => x.Id == model.Id);

                if (restaurantProductToUpdate == null)
                    return StatusCode(
                        StatusCodes.Status403Forbidden,
                        "Product not found"
                    );

                return Ok(await _productService.Update(model, restaurantProductToUpdate));
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    e
                );
            }
        }

        [Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpGet]
        [Route("get-all/{restaurantId}")]
        public async Task<IActionResult> GetAll(string restaurantId)
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
                    await _productService.GetAllByRestaurantId(currentUser.RestaurantUser.RestaurantId);

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
    }
}
