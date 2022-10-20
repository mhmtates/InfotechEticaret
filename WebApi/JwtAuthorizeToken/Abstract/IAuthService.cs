namespace WebApi.JwtAuthorizeToken.Abstract
{
    public interface IAuthService
    {
        string Authenticate(string username, string password);
    }
}
