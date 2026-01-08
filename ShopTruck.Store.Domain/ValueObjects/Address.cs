using ShopTruck.Store.Domain.Exceptions;

namespace ShopTruck.Store.Domain.ValueObjects;

public record class Address
    {
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }

    private Address() { } // EF Core

    public Address(string street, string city, string postalCode, string country)
        {
        if (string.IsNullOrWhiteSpace(street))
            throw new RequiredFieldException("Street is required");

        if (string.IsNullOrWhiteSpace(city))
            throw new RequiredFieldException("City is required");

        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
        }
    }

