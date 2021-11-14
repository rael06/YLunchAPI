using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using YLunch.Application.Exceptions;
using YLunch.Application.Services;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.Services.UserServices;
using YLunch.Infrastructure.Database;
using YLunch.Infrastructure.Database.Repositories;

namespace YLunch.Application.Tests
{
    public class UserServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private const string FIRST_USER_ID = "111";
        private const string NOT_EXISTING_ID = "abc";

        public UserServiceTests()
        {
            _context = ContextBuilder.BuildContext();
            InitContext();
            var userRepository = new UserRepository(null, null, _context);
            _userService = new UserService(userRepository);
        }

        private void InitContext()
        {
            var users = new List<User>
            {
                new()
                {
                    Id = FIRST_USER_ID,
                    UserName = "SUPERADMIN@YNOV.COM",
                    Firstname = "superadmin-firstname",
                    Lastname = "superadmin-lastname",
                    Email = null,
                    PhoneNumber = null,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    CreationDateTime = DateTime.Parse("2021-10-31T14:34:46.0431306"),
                    IsAccountActivated = false
                },
                new()
                {
                    Id = "222",
                    UserName = "CUSTOMER@YNOV.COM",
                    Firstname = "customer_firstname",
                    Lastname = "customer_lastname",
                    Email = "customer@ynov.com",
                    PhoneNumber = "0612345678",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    CreationDateTime = DateTime.Parse("2021-10-31T14:34:46.0431306"),
                    IsAccountActivated = false
                }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllUsers_Should_Return_All_Users()
        {
            // Act
            var actual = await _userService.GetAllUsers();

            // Assert
            var expected = await _context.Users.Select(u => new UserReadDto(u)).ToListAsync();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetAsCustomerById_Should_Return_A_Customer_Based_On_Input_Id()
        {
            // Arrange
            const string id = FIRST_USER_ID;

            // Act
            var actual = await _userService.GetAsCustomerById(id);

            // Assert
            var user = _context.Users.First();
            var expected = new UserAsCustomerDetailsReadDto(user);
            actual.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public async Task DeleteUserById_Should_Delete_A_User_Given_His_Id()
        {
            // Arrange
            const string id = FIRST_USER_ID;

            // Act
            await _userService.DeleteUserById(id);

            // Assert
            var user = await _context.Users.FindAsync(id);
            Assert.Null(user);
        }

        [Fact]
        public async Task DeleteUserById_Should_Throw_If_User_Not_Exists()
        {
            // Arrange
            const string id = NOT_EXISTING_ID;

            // Act
            async Task Act() => await _userService.DeleteUserById(id);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(Act);
        }
    }
}
