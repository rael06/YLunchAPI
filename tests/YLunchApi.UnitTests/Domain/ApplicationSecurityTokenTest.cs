using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using YLunchApi.Authentication.Models;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.UnitTests.Application.UserAggregate;

namespace YLunchApi.UnitTests.Domain;

public class ApplicationSecurityTokenTest
{
    [Fact]
    public void Should_Be_Valid()
    {
        // Arrange
        var user = UserMocks.RestaurantAdminUserReadDto("095f0658-8192-442d-9a3a-2b78c4268aa3");
        const string token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjA5NWYwNjU4LTgxOTItNDQyZC05YTNhLTJiNzhjNDI2OGFhMyIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwiUm9sZXMiOiJSZXN0YXVyYW50QWRtaW4iLCJqdGkiOiJkYTA1OWFhNy1iY2ZkLTRhOWQtYTExNy05Y2ZiNjA1MDE4ODciLCJuYmYiOjE2NDQyNjYwMDAsImV4cCI6MTY0NDI2NjMwMCwiaWF0IjoxNjQ0MjY2MDAwfQ.iYx0VEVQI11kFq6uM6haW_4qJRNwUEmZXnH9krq7x24";
        var expected = new ApplicationSecurityToken(token);

        // Act
        var actual = new ApplicationSecurityToken(token);
        expected.Should().BeEquivalentTo(actual, options =>
            options.Excluding(x => x.UserId)
        );
        actual.UserId.Should().Be(user.Id);
        actual.UserEmail.Should().Be(user.Email);
        actual.UserRoles.Should().BeEquivalentTo(new List<string> { Roles.RestaurantAdmin });
    }
}
