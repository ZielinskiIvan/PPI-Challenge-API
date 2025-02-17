using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class AssetTypeDTOValidator : AbstractValidator<AssetTypeDTO>
    {
        public AssetTypeDTOValidator() 
        {
            RuleFor(e => e.Description).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
        }
    }
}
