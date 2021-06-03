using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YnovEat.Api.Core.Response;
using YnovEat.Api.Core.Response.Errors;
using YnovEat.Application.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEatApi.Core.UserModels;

namespace YnovEat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration) : base(userManager)
        {
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user == null || !await UserManager.CheckPasswordAsync(user, model.Password)) return Unauthorized();

            var userRoles = await UserManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register-customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] UserRegisterDto model)
        {
            var userExists = await UserManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response {Status = ResponseStatus.Error, Message = "User already exists!"});

            var user = new User
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = ResponseStatus.Error,
                        Message = "User creation failed! Please check user details and try again."
                    });

            if (await _roleManager.RoleExistsAsync(UserRoles.Customer))
                await UserManager.AddToRoleAsync(user, UserRoles.Customer);

            return StatusCode(
                StatusCodes.Status201Created,
                new UserDto(user)
            );
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register-restaurantAdmin")]
        public async Task<IActionResult> RegisterRestaurantAdmin([FromBody] UserRegisterDto model)
        {
            var userExists = await UserManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response {Status = ResponseStatus.Error, Message = "User already exists!"});

            var user = new User
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = ResponseStatus.Error,
                        Message = "User creation failed! Please check user details and try again."
                    });

            if (await _roleManager.RoleExistsAsync(UserRoles.RestaurantAdmin))
                await UserManager.AddToRoleAsync(user, UserRoles.RestaurantAdmin);

            return StatusCode(
                StatusCodes.Status201Created,
                new UserDto(user)
            );
        }

        [Core.Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpPost]
        [Route("register-employee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] UserRegisterDto model)
        {
            var userExists = await UserManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response {Status = ResponseStatus.Error, Message = "User already exists!"});

            var user = new User
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = ResponseStatus.Error,
                        Message = "User creation failed! Please check user details and try again."
                    });

            if (await _roleManager.RoleExistsAsync(UserRoles.Employee))
                await UserManager.AddToRoleAsync(user, UserRoles.Employee);

            return StatusCode(
                StatusCodes.Status201Created,
                new UserDto(user)
            );
        }

        [Core.Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpPost]
        [Route("register-super-admin")]
        public async Task<IActionResult> RegisterSuperAdmin([FromBody] UserRegisterDto model)
        {
            var userExists = await UserManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response {Status = ResponseStatus.Error, Message = "User already exists!"});

            var user = new User
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = ResponseStatus.Error,
                        Message = "User creation failed! Please check user details and try again."
                    });

            if (!await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.RestaurantAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.RestaurantAdmin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Employee))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

            if (await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await UserManager.AddToRoleAsync(user, UserRoles.SuperAdmin);

            return StatusCode(
                StatusCodes.Status201Created,
                new UserDto(user)
            );
        }

        [Core.Authorize]
        [HttpGet("current-user")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var currentUser = await GetAuthenticatedUserDto();
            if (currentUser == null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new InvalidTokenErrorResponse()
                );

            return currentUser;
        }
    }
}
