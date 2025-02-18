using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(e => e.AssetID)
           .GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage) // Se mantiene MinimumLengthMessage
           .NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);

            RuleFor(e => e.Quantity).NotEmpty()
                .WithMessage(ValidationUtilities.NonEmptyMessage)
                .GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage);

            RuleFor(e => e.Price).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage)
                .GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage);

            RuleFor(e => e.Operation).NotEmpty().Must(op => op == 'C' || op == 'V')
            .WithMessage(ValidationUtilities.CaracterOperationValidValues);

        }
    }
}
