using System.Net;
using Common.Interfaces.Tools;

namespace Common.Models.Helper.ResultTypes
{
    public class Ok<T> : ObjectResult<T>, IResult
    {
        private T _body;

        public override T Body => _body;

        public override int StatusCode => (int)HttpStatusCode.OK;

        public override bool IsSuccess => true;

        public Ok(T item)
        {
            _body = item;
        }

        public static implicit operator Ok<T>(T value)
        {
            return new Ok<T>(value);
        }

        public static implicit operator T(Ok<T> objectResult)
        {
            return objectResult.Body;
        }

        public static implicit operator Ok<T>(Result result)
        {
            if (result.StatusCode != (int)HttpStatusCode.OK)
                throw new NullReferenceException("Invalid object");

            if (!typeof(T).IsAssignableFrom(result.Body.GetType()))
                throw new NullReferenceException("Invalid object");

            return new Ok<T>((T)result.Body);
        }
    }
}
