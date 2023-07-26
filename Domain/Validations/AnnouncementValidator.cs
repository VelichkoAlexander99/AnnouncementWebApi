using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
            
            RuleFor(dto => dto.Text)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(dto => dto.ImageUri)
                .NotEmpty()
                .Must(LinkMustBeAUri)
                .WithMessage(dto => $"Link '{dto.ImageUri}' must be a valid URI.");

            RuleFor(dto => dto.Rating)
                .NotEmpty()
                .InclusiveBetween(-10, 10);

            RuleFor(dto => dto.Expity)
                .NotEmpty()
                .GreaterThan(r => r.Created)
                .WithMessage("End date must after Start date");
        }

        private static bool LinkMustBeAUri(Uri link)
        {
            if (string.IsNullOrWhiteSpace(link.OriginalString))
                return false;

            return Uri.TryCreate(link.OriginalString, UriKind.Absolute, out var outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
