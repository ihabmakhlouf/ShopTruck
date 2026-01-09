using FluentValidation;

namespace ShopTruck.Store.Application.Commands;

public class CreateStoreValidateur : AbstractValidator<CreateStoreCommand>
    {
    public CreateStoreValidateur()
        {
        RuleFor(x => x.StoreDto.Name).NotNull()
                         .NotEmpty().WithMessage("{PropertyName} is required.")
                         .MinimumLength(3)
                         .MaximumLength(250)
                         .WithMessage("{PropertyName} must be fewer than 250 characters.");

        RuleFor(x => x.StoreDto.AddressDto).NotNull()
                                           .WithMessage("Address is required.");

        RuleFor(x => x.StoreDto.AddressDto.City).NotNull()
                         .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.StoreDto.AddressDto.Street).NotNull()
                         .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.StoreDto.AddressDto.Country).NotNull()
                         .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.StoreDto.AddressDto.PostalCode).NotNull()
                         .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }

