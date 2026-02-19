using MediatR;

namespace ShopTruck.Customer.Application.Commands;

public record AddCustomerCommand : IRequest<string>;


