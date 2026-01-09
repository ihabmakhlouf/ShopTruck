using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetStoreByIdQuery(Guid Guid) : IRequest<StoreDto>;

public class GetStoreByIdQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetStoreByIdQuery, StoreDto>
    {
    public async Task<StoreDto> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
        var store = await storeRepository.GetStoreByIdAsync(request.Guid);
        return new StoreDto
            {
            Id = store.Id,
            Name = store.Name,
            };
        }
    }

