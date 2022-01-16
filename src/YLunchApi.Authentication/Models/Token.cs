using Microsoft.IdentityModel.Tokens;

namespace YLunchApi.Authentication.Models;

public class Token
{
    public SecurityToken SecurityToken { get; }
    public string StringToken { get; }

    public Token(SecurityToken securityToken, string stringToken)
    {
        SecurityToken = securityToken;
        StringToken = stringToken;
    }
}
