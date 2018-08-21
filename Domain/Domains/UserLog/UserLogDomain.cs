using System;
using Solution.Infrastructure.Database;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
    public sealed class UserLogDomain : BaseDomain, IUserLogDomain
    {
        public UserLogDomain(IDatabaseUnitOfWork databaseUnitOfWork)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        public void Save(long userId, LogType logType)
        {
            var userLog = new UserLogModel
            {
                UserId = userId,
                LogType = logType,
                DateTime = DateTime.UtcNow
            };

            DatabaseUnitOfWork.UserLogRepository.Add(userLog);
            DatabaseUnitOfWork.SaveChanges();
        }
    }
}
