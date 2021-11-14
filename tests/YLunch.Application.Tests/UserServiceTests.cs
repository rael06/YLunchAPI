using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
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
                    Id = "111",
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
            // Arrange

            // Act
            var actual = await _userService.GetAllUsers();


            // Assert
            var expected = _context.Users.Select(u => new UserReadDto(u));

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetAsCustomerById_Should_Return_A_Customer_Based_On_Input_Id()
        {
            // Arrange
            var id = _context.Users.First().Id;

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
            var id = _context.Users.First().Id;

            // Act
            await _userService.DeleteUserById(id);

            // Assert
            var user = await _context.Users.FindAsync(id);
            Assert.Null(user);
        }
    }
}
