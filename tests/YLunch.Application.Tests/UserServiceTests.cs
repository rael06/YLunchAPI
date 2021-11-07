using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using YLunch.Application.Services;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Infrastructure.Database;
using YLunch.Infrastructure.Database.Repositories;

namespace YLunch.Application.Tests
{
    public class UserServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _context = ContextBuilder.BuildContext();
            InitContext();
            var userRepository = new UserRepository(null , null ,_context);
            _userService = new UserService(userRepository);
        }

        private void InitContext()
        {
            var user = new User
            {
                Id = "6899dc5a-3764-45d7-8d8f-91855f294f71",
                UserName = "RAEL06@HOTMAIL.FR",
                Firstname = "rael",
                Lastname = "calitro",
                Email = null,
                PhoneNumber = null,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                CreationDateTime = DateTime.Parse("2021-10-31T14:34:46.0431306"),
                IsAccountActivated = false
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllUsers_Should_Return_All_Users()
        {
            var expected = _context.Users.Count();
            var result = (await _userService.GetAllUsers()).Count;

            Assert.Equal(expected, result);
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
            actual.Should().NotBeEquivalentTo(expected);
        }
    }
}
