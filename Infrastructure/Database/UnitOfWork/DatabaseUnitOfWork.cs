namespace Solution.Infrastructure.Database
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        public DatabaseUnitOfWork(
            IUserLogRepository userLogRepository,
            IUserRepository userRepository,
            DatabaseContext databaseContext)
        {
            UserLogRepository = userLogRepository;
            UserRepository = userRepository;
            Context = databaseContext;
        }

        public IUserLogRepository UserLogRepository { get; }

        public IUserRepository UserRepository { get; }

        private DatabaseContext Context { get; }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
