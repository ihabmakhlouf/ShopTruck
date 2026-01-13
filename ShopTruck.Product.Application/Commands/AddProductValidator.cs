using FluentValidation;
using MyApp.Application.Commands;

namespace ShopTruck.Product.Application.Commands;

public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
    public AddProductValidator() 
        {
        RuleFor(x => x.productDto.Name).NotNull()
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .MinimumLength(3)
                        .MaximumLength(250)
                        .WithMessage("{PropertyName} must be fewer than 250 characters.");

        RuleFor(x => x.productDto.Description).NotNull()
                             .NotEmpty().WithMessage("{PropertyName} is required.")
                             .MaximumLength(250);

        RuleFor(x => x.productDto.Price).NotNull()
                                        .GreaterThan(0);
        }
    }

