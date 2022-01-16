using System.IdentityModel.Tokens.Jwt;
using FluentAssertions;
using Xunit;
using YLunchApi.Authentication.Models;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.UnitTests.Domain;

public class ApplicationSecurityTokenTest
{
    [Fact]
    public void Should_Be_Valid()
    {
        // Arrange
        var user = UserMocks.RestaurantAdminUserReadDto("03371895-6eb0-4a46-9401-57635f42f9ea");
        const string token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjAzMzcxODk1LTZlYjAtNGE0Ni05NDAxLTU3NjM1ZjQyZjllYSIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwianRpIjoiNzEyZWZkZDYtNzQwZS00YmFlLThkMTYtMzY5NzM0NzMwZDdjIiwibmJmIjoxNjQyMzY4NTY3LCJleHAiOjE2NDIzNjg4NjcsImlhdCI6MTY0MjM2ODU2N30.cENrwSlv1BsFbwX2R_iGyMTgUFqAMN2FqBbFlEeZSQA";
        var handler = new JwtSecurityTokenHandler();
        var expected = handler.ReadJwtToken(token);

        // Act
        var actual = new ApplicationSecurityToken(token);
        expected.Should().BeEquivalentTo(actual, options =>
            options.Excluding(x => x.UserId)
        );
        actual.UserId.Should().Be(user.Id);
        actual.Subject.Should().Be(user.Email);
    }
}
