﻿using FluentValidation;
using PPI_Challenge_API.DTO.RequestDTO;
using PPI_Challenge_API.Utilities;

namespace PPI_Challenge_API.Validators
{
    public class AssetUpdateDTOValidator : AbstractValidator<AssetUpdateDTO>
    {
        public AssetUpdateDTOValidator()
        {
            RuleFor(e => e.Id).GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(e => e.AssetTypeID).GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(e => e.Ticker).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(e => e.Name).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage);
            RuleFor(e => e.UnitPrice).NotEmpty().WithMessage(ValidationUtilities.NonEmptyMessage).GreaterThan(0).WithMessage(ValidationUtilities.MinimumLengthMessage);
        }
    }
}
