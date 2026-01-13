using FluentValidation;

namespace ShopTruck.Product.Application.Commands
    {
    public class UpdateProductValidator :AbstractValidator<UpdateProductByIdCommand>
        {
        public UpdateProductValidator()
            {
            RuleFor(x => x.ProductDto.Name).NotNull()
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .MinimumLength(3)
                  .MaximumLength(250)
                  .WithMessage("{PropertyName} must be fewer than 250 characters.");

            RuleFor(x => x.ProductDto.Description).NotNull()
                                 .NotEmpty().WithMessage("{PropertyName} is required.")
                                 .MaximumLength(250);

            RuleFor(x => x.ProductDto.Price).NotNull()
                                            .GreaterThan(0);
            }
        }
    }
