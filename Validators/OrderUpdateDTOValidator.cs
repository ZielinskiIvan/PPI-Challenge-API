using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class OrderDTOUpdateValidator : AbstractValidator<OrderUpdateDTO>
    {
        public OrderDTOUpdateValidator()
        {
            RuleFor(e => e.Id)
           .GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage)
           .NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            
            RuleFor(e => e.StateId)
            .GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage)
            .NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
        }
    }
}
