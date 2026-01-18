using FluentValidation;

namespace ShopTruck.Store.Application.Commands
    {
    public class AddVendorValidator : AbstractValidator<AddVendorCommand>
        {
        public AddVendorValidator()
            {
            RuleFor(x => x.VendorDto.FirstName).NotNull()
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .MinimumLength(3)
                 .MaximumLength(250)
                 .WithMessage("{PropertyName} must be fewer than 250 characters.");

            RuleFor(x => x.VendorDto.LastName).NotNull()
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .MinimumLength(3)
                 .MaximumLength(250)
                 .WithMessage("{PropertyName} must be fewer than 250 characters.");

            RuleFor(x => x.VendorDto.AddressMail).NotNull()
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                 .MaximumLength(250)
                 .WithMessage("{PropertyName} must be fewer than 250 characters.");

            RuleFor(x => x.VendorDto.Password).NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(12);
            }
        }
    }
