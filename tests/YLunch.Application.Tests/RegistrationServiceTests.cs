using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using YLunch.Application.Services;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Infrastructure.Database;
using YLunch.Infrastructure.Database.Repositories;

namespace YLunch.Application.Tests
{
    public class RegistrationServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly RegistrationService _registrationService;

        public RegistrationServiceTests()
        {
            _context = ContextBuilder.BuildContext();
            var userManagerMock = ManagerMocker.GetUserManagerMock(_context);
            var roleManagerMock = ManagerMocker.GetRoleManagerMock(_context);
            var userRepository = new UserRepository(userManagerMock.Object, roleManagerMock.Object, _context);
            _registrationService = new RegistrationService(userRepository);
        }

        [Fact]
        public async Task Register_Should_Register_A_SuperAdmin_User()
        {
            // Arrange
            var user = new SuperAdminCreationDto
            {
                UserName = "superadmin@ynov.com",
                Password = "Password1234.",
                Firstname = "superadmin-firstname",
                Lastname = "superadmin-lastname"
            };

            // Act
            var actual = await _registrationService.Register(user);

            // Assert
            var contextUser = await _context.Users.FirstOrDefaultAsync();
            var expected = new UserReadDto(contextUser);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Register_Should_Register_A_Customer_User()
        {
            // Arrange
            var user = new CustomerCreationDto
            {
                UserName = "customer@ynov.com",
                Password = "Password1234.",
                Firstname = "customer_firstname",
                Lastname = "customer_lastname",
                PhoneNumber = "0612345678"
            };

            // Act
            var actual = await _registrationService.Register(user);

            // Assert
            var contextUser = await _context.Users.FirstOrDefaultAsync();
            var expected = new UserReadDto(contextUser);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Register_Should_Register_A_RestaurantOwner_User()
        {
            // Arrange
            var user = new RestaurantOwnerCreationDto
            {
                UserName = "restaurant-owner@restaurant.com",
                Password = "Password1234.",
                Firstname = "restaurant-owner_firstname",
                Lastname = "restaurant-owner_lastname"
            };

            // Act
            var actual = await _registrationService.Register(user);

            // Assert
            var contextUser = await _context.Users.FirstOrDefaultAsync();
            var expected = new UserReadDto(contextUser);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Register_Should_Register_A_RestaurantAdmin_User()
        {
            // Arrange
            var user = new RestaurantAdminCreationDto
            {
                UserName = "restaurant-admin@restaurant.com",
                Password = "Password1234.",
                Firstname = "restaurant-admin_firstname",
                Lastname = "restaurant-admin_lastname"
            };

            // Act
            var actual = await _registrationService.Register(user);

            // Assert
            var contextUser = await _context.Users.FirstOrDefaultAsync();
            var expected = new UserReadDto(contextUser);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Register_Should_Register_An_Employee_User()
        {
            // Arrange
            var user = new EmployeeCreationDto
            {
                UserName = "employee@restaurant.com",
                Password = "Password1234.",
                Firstname = "employee_firstname",
                Lastname = "employee_lastname"
            };

            // Act
            var actual = await _registrationService.Register(user);

            // Assert
            var contextUser = await _context.Users.FirstOrDefaultAsync();
            var expected = new UserReadDto(contextUser);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
