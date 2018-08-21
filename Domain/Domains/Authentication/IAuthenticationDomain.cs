using Solution.Model.Models;

namespace Solution.Domain.Domains
{
    public interface IAuthenticationDomain : IBaseDomain
    {
        string Authenticate(AuthenticationModel authentication);

        void Logout(long userId);
    }
}
