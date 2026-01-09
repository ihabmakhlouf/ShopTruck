namespace ShopTruck.Store.Domain.Exceptions;

public class RequiredFieldException : Exception
    {
    public RequiredFieldException(string field)
        : base($"{field} is required.")
        {
        }
    }

