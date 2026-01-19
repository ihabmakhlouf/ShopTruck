using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetStoresByVendorIdQuery(Guid vendorId) : IRequest<IEnumerable<StoreDto>>;

public class GetStoresByVendorIdQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetStoresByVendorIdQuery, IEnumerable<StoreDto>>
    {
    public async Task<IEnumerable<StoreDto>> Handle(GetStoresByVendorIdQuery request, CancellationToken cancellationToken)
        {
        var stores = await storeRepository.GetStoresByVendorIdAsync(request.vendorId);
        return stores.Select(x => new StoreDto
            {
            Id = x.Id,
            Name = x.Name,
            VendorId = x.VendorId,
            AddressDto = new AddressDto
                {
                City = x.Address.City,
                Country = x.Address.Country,
                PostalCode = x.Address.PostalCode,
                Street = x.Address.Street,
                }
            }).ToList();
        }
    }

