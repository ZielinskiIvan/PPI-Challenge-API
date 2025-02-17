using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class StateDTOValidatorValidator : AbstractValidator<StateDTO>
    {
        public StateDTOValidatorValidator()
        {
            RuleFor(e => e.Description).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
        }
    }
}
