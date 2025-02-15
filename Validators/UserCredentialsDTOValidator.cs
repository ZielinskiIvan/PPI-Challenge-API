using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;

namespace PPI_Challenge_API.Validators
{
    public class UserCredentialsDTOValidator: AbstractValidator<UserCredentialsDTO>
    {
        public UserCredentialsDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage)
                                 .MaximumLength(256).WithMessage(ValidationUtilities.MaximumLengthMessage)
                                 .EmailAddress().WithMessage(ValidationUtilities.EmailAddressMessage);

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage)
            .MinimumLength(6).WithMessage(ValidationUtilities.MinimumLengthMessage)
            .Matches(@"[A-Z]").WithMessage(ValidationUtilities.UpperCaseMessage)
            .Matches(@"\d").WithMessage(ValidationUtilities.DigitMessage)
            .Matches(@"[\W_]").WithMessage(ValidationUtilities.NotAlphanumericMessage);

            RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage)
                                    .MinimumLength(6).WithMessage(ValidationUtilities.MinimumLengthMessage);

        }
    }
}
