using Common.Interfaces.Tools;
using System.Net;

namespace Common.Models.Helper.ResultTypes
{
    public class BadRequest<T> : ObjectResult<T>, IResult
    {
        private string? _message;
        public override string? Message => _message;
        public override int StatusCode => (int)HttpStatusCode.BadRequest;
        public override bool IsSuccess => false;
        public BadRequest(string? message)
        {
            _message = message;

        }

        public static implicit operator BadRequest<T>(string value)
        {
            return new BadRequest<T>(value);
        }

        public static implicit operator T?(BadRequest<T> objectResult)
        {
            return default;
        }

        public static implicit operator BadRequest<T>(Result result)
        {
            if (result.StatusCode != (int)HttpStatusCode.BadRequest)
                throw new NullReferenceException("Invalid object");

            if (result.Body != null && !typeof(string).IsAssignableFrom(result.Body.GetType()))
                throw new NullReferenceException("Invalid object");

            return new BadRequest<T>((string?)result.Body);
        }
    }
}
