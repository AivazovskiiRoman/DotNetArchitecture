using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogModel>
    {
    }
}
