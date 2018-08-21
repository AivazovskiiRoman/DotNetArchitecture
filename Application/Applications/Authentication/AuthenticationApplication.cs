using Solution.Domain.Domains;
using Solution.Model.Models;

namespace Solution.Application.Applications
{
    public sealed class AuthenticationApplication : BaseApplication, IAuthenticationApplication
    {
        public AuthenticationApplication(IAuthenticationDomain authenticationDomain)
        {
            AuthenticationDomain = authenticationDomain;
        }

        private IAuthenticationDomain AuthenticationDomain { get; }

        public string Authenticate(AuthenticationModel authentication)
        {
            return AuthenticationDomain.Authenticate(authentication);
        }

        public void Logout(long userId)
        {
            AuthenticationDomain.Logout(userId);
        }
    }
}
