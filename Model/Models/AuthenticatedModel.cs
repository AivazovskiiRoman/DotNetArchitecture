using Solution.Model.Enums;

namespace Solution.Model.Models
{
    public class AuthenticatedModel
    {
        public Roles Roles { get; set; }

        public long UserId { get; set; }
    }
}
