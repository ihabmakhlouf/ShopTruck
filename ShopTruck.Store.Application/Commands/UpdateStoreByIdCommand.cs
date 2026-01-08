using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Commands;

public record UpdateStoreByIdCommand(Guid Guid) : IRequest<StoreDto>;

public class UpdateStoreByIdCommandHandler(IStoreRepository storeRepository) : IRequestHandler<UpdateStoreByIdCommand, StoreDto>
    {
    public async Task<StoreDto> Handle(UpdateStoreByIdCommand request, CancellationToken cancellationToken)
        {
        var store = await storeRepository.UpdateStoreByIdAsync(request.Guid);
        return new StoreDto
            {
            Id = store.Id,
            Name = store.Name
            };
        }
    }
