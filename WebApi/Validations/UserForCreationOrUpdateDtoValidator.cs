using FluentValidation;
using WebApi.DTOs.Incoming;

namespace WebApi.Validations
{
    public class UserForCreationOrUpdateDtoValidator : AbstractValidator<UserForCreationOrUpdateDto>
    {
        public UserForCreationOrUpdateDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(25);

            RuleFor(dto => dto.IsAdmin)
                .NotEmpty();
        }
    }
}
