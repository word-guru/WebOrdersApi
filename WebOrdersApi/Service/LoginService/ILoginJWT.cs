using WebOrdersApi.Data.Entity;

namespace WebOrdersApi.Service.LoginService
{
    public interface ILoginJWT
    {
        Task<IResult> GetToken(string login, string password);
    }
}