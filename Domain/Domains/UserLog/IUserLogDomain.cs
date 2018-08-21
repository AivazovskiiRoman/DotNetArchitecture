using Solution.Model.Enums;

namespace Solution.Domain.Domains
{
    public interface IUserLogDomain : IBaseDomain
    {
        void Save(long userId, LogType logType);
    }
}
