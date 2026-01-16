using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Commands;


public record CreateStoreCommand(StoreDto StoreDto) : IRequest<StoreDto>;

public class CreateStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<CreateStoreCommand, StoreDto>
    {

    public async Task<StoreDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
        var newStore = await storeRepository.AddStoreAsync(new Domain.Entities.Store 
            { 
            Name = request.StoreDto.Name,
            Address = new Domain.ValueObjects.Address(
                request.StoreDto.AddressDto.Street, 
                request.StoreDto.AddressDto.City,
                request.StoreDto.AddressDto.PostalCode,
                request.StoreDto.AddressDto.Country),
            VendorId = request.StoreDto.VendorId,
            }
            
        );
        return new StoreDto
            {
            Id = newStore.Id,
            Name = newStore.Name,
            VendorId = newStore.VendorId,
            AddressDto = new AddressDto
                {
                City = newStore.Address.City,
                Street = newStore.Address.Street,
                PostalCode = newStore.Address.PostalCode,
                }
            };
        }
    }
