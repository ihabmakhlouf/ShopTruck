using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTruck.Store.Domain.Exceptions;

public class RequiredFieldException : Exception
    {
    public RequiredFieldException(string field)
        : base($"{field} is required.")
        {
        }
    }

