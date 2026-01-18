using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Commands;

public record UpdateStoreByIdCommand(Guid Guid, StoreDto StoreDto) : IRequest<StoreDto>;

public class UpdateStoreByIdCommandHandler(IStoreRepository storeRepository) : IRequestHandler<UpdateStoreByIdCommand, StoreDto>
    {
    public async Task<StoreDto> Handle(UpdateStoreByIdCommand request, CancellationToken cancellationToken)
        {
        var store = new Domain.Entities.Store
            {
            Name = request.StoreDto.Name,
            Address = new Domain.ValueObjects.Address(
                request.StoreDto.AddressDto.Street,
                request.StoreDto.AddressDto.City,
                request.StoreDto.AddressDto.PostalCode,
                request.StoreDto.AddressDto.Country),
            };
        store = await storeRepository.UpdateStoreByIdAsync(request.Guid, store);
        return new StoreDto
            {
            Id = store.Id,
            Name = store.Name
            };
        }
    }
