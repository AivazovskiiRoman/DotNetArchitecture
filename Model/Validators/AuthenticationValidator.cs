using FluentValidation;
using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Model.Validators
{
    public sealed class AuthenticationValidator : Validator<AuthenticationModel>
    {
        public AuthenticationValidator() : base(Texts.AuthenticationInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Login).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
