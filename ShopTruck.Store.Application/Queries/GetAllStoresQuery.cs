using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetAllStoresQuery : IRequest<IEnumerable<StoreDto>>;

public class GetAllStoresQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetAllStoresQuery, IEnumerable<StoreDto>>
    {
    public async Task<IEnumerable<StoreDto>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
        var stores = await storeRepository.GetStoresAsync();
        return stores.Select(x => new StoreDto
            {
            Id = x.Id,
            Name = x.Name,
            AddressDto = new AddressDto
                {
                City = x.Address.City,
                PostalCode = x.Address.PostalCode,
                Street = x.Address.Street,
                }
            });
        }
    }
