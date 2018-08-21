using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public interface IUserRepository : IRelationalRepository<UserModel>
    {
        AuthenticatedModel Authenticate(AuthenticationModel authentication);
    }
}
