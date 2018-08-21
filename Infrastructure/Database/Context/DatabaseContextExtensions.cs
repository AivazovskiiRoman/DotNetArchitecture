using Solution.CrossCutting.Security;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public static class DatabaseContextExtensions
    {
        public static void Seed(this DatabaseContext context)
        {
            SeedUsers(context);
            context.SaveChanges();
        }

        private static void SeedUsers(DatabaseContext context)
        {
            if (context.Users.Find(1L) != null)
            {
                return;
            }

            var hash = new Hash();

            var userModel = new UserModel
            {
                Name = "Administrator",
                Surname = "Administrator",
                Email = "administrator@administrator.com",
                Login = hash.Create("admin"),
                Password = hash.Create("admin"),
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active
            };

            context.Users.Add(userModel);
        }
    }
}
