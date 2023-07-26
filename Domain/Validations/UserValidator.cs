using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(dto => dto.IsAdmin)
                .NotEmpty();
        }
    }
}
