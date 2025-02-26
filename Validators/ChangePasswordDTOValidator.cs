﻿using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class ChangePasswordDTOValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage)
                     .MaximumLength(256).WithMessage(ValidationUtilities.MaximumLengthMessage)
                     .EmailAddress().WithMessage(ValidationUtilities.EmailAddressMessage);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(x => x.RepeatPassword).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(x => x.Password)
                .Equal(x => x.RepeatPassword)
                .WithMessage(x => ValidationUtilities.PasswordEqualsToRepeatedPassword
                    .Replace("{PropertyName2}", nameof(x.RepeatPassword)));
        }
    }
}
