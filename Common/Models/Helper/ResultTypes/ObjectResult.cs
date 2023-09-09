using System.Net;
using Common.Interfaces.Tools;

namespace Common.Models.Helper.ResultTypes
{
    public abstract class ObjectResult<TEntity> : IObjectResult<TEntity>, IResult
    {
        public virtual TEntity? Body => default;

        public virtual int StatusCode => 0;

        public virtual string? Message => default;

        public abstract bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public object? GetBody()
        {
            if (IsSuccess)
            {
                return Body;
            }
            else
            {
                return Message;
            }
        }

        public Result Convert()
        {
            return new Result(Body, StatusCode);
        }

        public static implicit operator ObjectResult<TEntity>(TEntity value)
        {
            return new Ok<TEntity>(value);
        }

        public static implicit operator TEntity?(ObjectResult<TEntity> objectResult)
        {
            return objectResult.Body;
        }

        public static implicit operator ObjectResult<TEntity>(Result result)
        {
            switch (result.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return (Ok<TEntity>)result;
                case (int)HttpStatusCode.NoContent:
                    return (NoContent<TEntity>)result;
                case (int)HttpStatusCode.BadRequest:
                    return (BadRequest<TEntity>)result;
                case (int)HttpStatusCode.NotFound:
                    return (NotFound<TEntity>)result;
                case (int)HttpStatusCode.Unauthorized:
                    return (NotAuthorized<TEntity>)result;
                default:
                    throw new NullReferenceException("Invallid Operation!");
            }
        }
    }
}
