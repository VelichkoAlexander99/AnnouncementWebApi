using FluentValidation;
using WebApi.DTOs.Incoming;

namespace WebApi.Validations
{
    public class AnnouncementForUpdateDtoValidator : AbstractValidator<AnnouncementForUpdateDto>
    {
        public AnnouncementForUpdateDtoValidator()
        {
            RuleFor(dto => dto.Text)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(dto => dto.ImageUri)
                .NotEmpty()
                .Must(LinkMustBeAUri)
                .WithMessage(dto => $"Link '{dto.ImageUri}' must be a valid URI.");

            RuleFor(dto => dto.Rating)
                .InclusiveBetween(-10, 10);

            RuleFor(dto => dto.Expity)
                .NotEmpty()
                .GreaterThan(r => r.Created)
                .WithMessage("End date must after Start date");
        }

        public static bool LinkMustBeAUri(Uri link)
        {
            if (string.IsNullOrWhiteSpace(link.OriginalString))
                return false;

            return Uri.TryCreate(link.OriginalString, UriKind.Absolute, out var outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
