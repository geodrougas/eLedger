using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Tools
{
    public interface IResult
    {
        int StatusCode { get; }
        bool IsSuccess { get; }
        bool IsFailure { get; }
        object? GetBody();
    }
}
