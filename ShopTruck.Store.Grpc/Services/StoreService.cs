using Grpc.Core;
using MediatR;
using ShopTruck.Store.Application.Queries;


namespace ShopTruck.Store.Grpc.Services;

public class StoreService(ISender sender) : StoreGrpcService.StoreGrpcServiceBase
    {
    public override async Task<GetStoreByIdResponse> GetStoreById(GetStoreByIdRequest request, ServerCallContext context)
        {
        if (!Guid.TryParse(request.Id, out var storeId))
            {
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid store ID"));
            }
        var store = await sender.Send(new GetStoreByIdQuery(storeId));

        return new GetStoreByIdResponse
            {
            Name = store.Name,
            City = store.AddressDto.City,
            Country = store.AddressDto.Country,
            PostalCode = store.AddressDto.PostalCode,
            Street = store.AddressDto.Street,
            };
        }
    }

