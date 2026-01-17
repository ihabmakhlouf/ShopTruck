using Grpc.Core;
using MediatR;
using ShopTruck.Store.Application.Queries;
using ShopTruck.Store.Grpc.Protos;

namespace ShopTruck.Store.Grpc.Services;

public class VendorService(ISender sender) : VendorGrpcService.VendorGrpcServiceBase
    {
    public override async Task<GetVendorByIdResponse> GetVendorById(GetVendorByIdRequest request, ServerCallContext context)
        {
        if (!Guid.TryParse(request.Id, out var vendorId))
            {
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid vendor ID"));
            }

        var vendor = await sender.Send(new GetVendorByIdQuery(vendorId));

        return new GetVendorByIdResponse
            {
            FirstName = vendor.FirstName,
            LastName = vendor.LastName,
            Email = vendor.AddressMail
            };
        }
    }