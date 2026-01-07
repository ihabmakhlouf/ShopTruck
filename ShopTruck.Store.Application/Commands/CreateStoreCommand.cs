using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Commands;

   
public record CreateStoreCommand(StoreDto StoreDto) :IRequest<StoreDto>;

public class CreateStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<CreateStoreCommand, StoreDto>
    {

    public async Task<StoreDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
        var newStore = await storeRepository.AddStoreAsync(new Domain.Entities.Store { Name = request.StoreDto.Name });
        return new StoreDto { Name = newStore.Name };
        }
    }
