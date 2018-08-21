using System.Collections.Generic;
using Solution.CrossCutting.Utils;
using Solution.Infrastructure.Database;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
    public sealed class UserDomain : BaseDomain, IUserDomain
    {
        public UserDomain(IDatabaseUnitOfWork databaseUnitOfWork)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        public PagedList<UserModel> List(PagedListParameters parameters)
        {
            return DatabaseUnitOfWork.UserRepository.List(parameters);
        }

        public IEnumerable<UserModel> List()
        {
            return DatabaseUnitOfWork.UserRepository.List();
        }

        public UserModel Select(long userId)
        {
            return DatabaseUnitOfWork.UserRepository.Select(userId);
        }
    }
}
