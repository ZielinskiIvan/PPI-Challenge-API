using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class AssetTypeUpdateDTOValidator : AbstractValidator<AssetTypeUpdateDTO>
    {
        public AssetTypeUpdateDTOValidator() 
        {
            RuleFor(e => e.Description).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage); 
            RuleFor(e => e.Id).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
        }
    }
}
