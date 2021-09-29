using CleanArchitecture.ApplicationCore.DTOs;
using FluentValidation;

namespace CleanArchitecture.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.BirthDay)
               .NotNull()
               .NotEmpty();

            RuleFor(user => user.Email)
               .NotNull()
               .NotEmpty();

            RuleFor(user => user.FirstName)
               .NotNull()
               .NotEmpty();
            RuleFor(user => user.LastName)
               .NotNull()
               .NotEmpty();

            RuleFor(user => user.PhoneNumber)
               .NotNull()
                .NotEmpty();

            RuleFor(user => user.Role)
               .NotNull()
               .NotEmpty();
        }
    }
}
