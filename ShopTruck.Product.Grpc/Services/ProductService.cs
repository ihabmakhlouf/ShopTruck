using Grpc.Core;
using MediatR;
using ShopTruck.Product.Application.Queries;
using ShopTruck.Product.Grpc.Protos;

namespace ShopTruck.Product.Grpc.Services
    {
    public class ProductService(ISender sender) : ProductServiceGrpc.ProductServiceGrpcBase
        {

        public override async Task<GetProductResponse> GetProductById(GetProductRequest request, ServerCallContext context)
            {
            if (!Guid.TryParse(request.Id, out var productId))
                {
                throw new RpcException(
                    new Status(StatusCode.InvalidArgument, "Invalid product ID"));
                }
            var product = await sender.Send(new GetProductByIdQuery(productId));

            return new GetProductResponse
                {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId.ToString(),
                Price = product.Price
                };
            }
        }
    }
