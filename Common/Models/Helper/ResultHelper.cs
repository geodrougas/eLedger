using Common.Models.Helper.ResultTypes;

namespace Common.Models.Helper
{
    public static class ResultHelper
    {
        public static Ok<TEntity> Ok<TEntity>(TEntity item)
        {
            return new Ok<TEntity>(item);
        }

        public static NoContent<TEntity> NoContent<TEntity>()
        {
            return new NoContent<TEntity>();
        }

        public static BadRequest<TEntity> BadRequest<TEntity>(string? message = null)
        {
            return new BadRequest<TEntity>(message);
        }

        public static NotFound<TEntity> NotFound<TEntity>(string? message = null)
        {
            return new NotFound<TEntity>(message);
        }

        public static NotAuthorized<TEntity> NotAuthorized<TEntity>(string? message = null)
        {
            return new NotAuthorized<TEntity>(message);
        }
    }
}
