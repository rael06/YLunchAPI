using System.IdentityModel.Tokens.Jwt;

namespace YLunchApi.Authentication.Models;

public sealed class ApplicationSecurityToken : JwtSecurityToken
{
    public ApplicationSecurityToken(string jwtEncodedString) : base(jwtEncodedString)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(jwtEncodedString);
        UserId = jwtSecurityToken.Claims.First(x => x.Type.Equals("Id")).Value;
    }

    public string UserId { get; }
}
