using Solution.CrossCutting.Security;
using Solution.Infrastructure.Database;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Model.Validators;

namespace Solution.Domain.Domains
{
    public sealed class AuthenticationDomain : BaseDomain, IAuthenticationDomain
    {
        public AuthenticationDomain(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IHash hash,
            IJsonWebToken jsonWebToken,
            IUserLogDomain userLogDomain)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            Hash = hash;
            JsonWebToken = jsonWebToken;
            UserLogDomain = userLogDomain;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IHash Hash { get; }
        private IJsonWebToken JsonWebToken { get; }
        private IUserLogDomain UserLogDomain { get; }

        public string Authenticate(AuthenticationModel authentication)
        {
            new AuthenticationValidator().ValidateThrow(authentication);

            SetHash(authentication);

            var authenticated = DatabaseUnitOfWork.UserRepository.Authenticate(authentication);

            new AuthenticatedValidator().ValidateThrow(authenticated);

            UserLogDomain.Save(authenticated.UserId, LogType.Login);

            return GetJwt(authenticated);
        }

        public void Logout(long userId)
        {
            UserLogDomain.Save(userId, LogType.Logout);
        }

        private string GetJwt(AuthenticatedModel authenticated)
        {
            var roles = authenticated.Roles.ToString().Split(", ");
            return JsonWebToken.Encode(authenticated.UserId.ToString(), roles);
        }

        private void SetHash(AuthenticationModel authentication)
        {
            authentication.Login = Hash.Create(authentication.Login);
            authentication.Password = Hash.Create(authentication.Password);
        }
    }
}
