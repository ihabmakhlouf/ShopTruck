using MediatR;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Commands;

public record DeleteStoreByIdCommand(Guid Guid) : IRequest<bool>;

public class DeleteStoreCommandHandler(IStoreRepository storeRepository) : IRequestHandler<DeleteStoreByIdCommand, bool>
    {
    public Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
        {
        throw new NotImplementedException();
        }
    }

