using FluentValidation;
using WebApi.DTOs.Incoming;

namespace WebApi.Validations
{
    public class AnnouncementForCreationDtoValidator : AbstractValidator<AnnouncementForCreationDto>
    {
        public AnnouncementForCreationDtoValidator()
        {
            RuleFor(dto => dto.UserId)
                .NotEmpty();

            RuleFor(dto => dto.Text)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(dto => dto.ImageUri)
                .NotEmpty()
                .Must(AnnouncementForUpdateDtoValidator.LinkMustBeAUri)
                .WithMessage(dto => $"Link '{dto.ImageUri}' must be a valid URI.");

            RuleFor(dto => dto.Rating)
                .InclusiveBetween(-10, 10);

            RuleFor(dto => dto.Expity)
                .NotEmpty()
                .GreaterThan(r => DateTime.Now)
                .WithMessage("End date must after Start date");
        }
    }
}
