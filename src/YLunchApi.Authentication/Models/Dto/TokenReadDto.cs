namespace YLunchApi.Authentication.Models.Dto;

public class TokenReadDto
{
    public string AccessToken { get; }
    public string RefreshToken { get; }

    public TokenReadDto(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
