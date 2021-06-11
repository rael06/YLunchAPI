using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YnovEat.Application.DTO.UserModels;
using YnovEat.Application.DTO.UserModels.Registration;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;

namespace YnovEat.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegistrationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private async Task<UserDto> Register(RegisterSuperAdminDto registerSuperAdminDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerSuperAdminDto.Username,
                Lastname = registerSuperAdminDto.Lastname,
                Firstname = registerSuperAdminDto.Firstname
            };
            var result = await _userManager.CreateAsync(user, registerSuperAdminDto.Password);

            // Todo create exception
            if (!result.Succeeded)
                throw new UserCreationException();

            if (!await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.RestaurantAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.RestaurantAdmin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Employee))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

            if (await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await _userManager.AddToRoleAsync(user, UserRoles.SuperAdmin);

            return new UserDto(user);
        }

        private async Task<UserDto> Register(RegisterRestaurantAdminDto registerRestaurantAdminDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerRestaurantAdminDto.Username,
                Lastname = registerRestaurantAdminDto.Lastname,
                Firstname = registerRestaurantAdminDto.Firstname
            };
            var result = await _userManager.CreateAsync(user, registerRestaurantAdminDto.Password);

            if (!result.Succeeded)
                throw new UserCreationException();

            await _userManager.AddToRoleAsync(user, UserRoles.RestaurantAdmin);

            return new UserDto(user);
        }

        private async Task<UserDto> Register(RegisterEmployeeDto registerEmployeeDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerEmployeeDto.Username,
                Lastname = registerEmployeeDto.Lastname,
                Firstname = registerEmployeeDto.Firstname
            };
            var result = await _userManager.CreateAsync(user, registerEmployeeDto.Password);

            if (!result.Succeeded)
                throw new UserCreationException();

            await _userManager.AddToRoleAsync(user, UserRoles.Employee);

            return new UserDto(user);
        }

        private async Task<UserDto> Register(RegisterCustomerDto registerCustomerDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerCustomerDto.Username,
                Lastname = registerCustomerDto.Lastname,
                Firstname = registerCustomerDto.Firstname,
                Email = registerCustomerDto.Username,
                PhoneNumber = registerCustomerDto.PhoneNumber,
                CreationDateTime = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, registerCustomerDto.Password);

            if (!result.Succeeded)
                throw new UserCreationException();

            await _userManager.AddToRoleAsync(user, UserRoles.Customer);

            return new UserDto(user);
        }

        public async Task<UserDto> Register<T>(T registerUserDto) where T : RegisterUserDto
        {
            return registerUserDto switch
            {
                RegisterSuperAdminDto registerSuperAdminDto => await Register(registerSuperAdminDto),
                RegisterRestaurantAdminDto registerRestaurantAdminDto => await Register(registerRestaurantAdminDto),
                RegisterEmployeeDto registerEmployeeDto => await Register(registerEmployeeDto),
                RegisterCustomerDto registerCustomerDto => await Register(registerCustomerDto),
                _ => throw new UserCreationException()
            };
        }
    }
}
