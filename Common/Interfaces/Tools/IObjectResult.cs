using Common.Models.Helper.ResultTypes;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Tools
{
    public interface IObjectResult<TEntity>
    {
        TEntity? Body { get; }
        string? Message { get; }
        int StatusCode { get; }
        bool IsSuccess { get; }
        bool IsFailure { get; }

        Result Convert();

    }
}
