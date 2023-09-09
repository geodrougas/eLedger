using System.Net;
using Common.Interfaces.Tools;

namespace Common.Models.Helper.ResultTypes
{
    public class NotFound<T> : ObjectResult<T>, IResult
    {
        private string? _message;
        public override string? Message => _message;
        public override int StatusCode => (int)HttpStatusCode.NotFound;
        public override bool IsSuccess => false;
        public NotFound(string? message)
        {
            _message = message;
        }

        public static implicit operator NotFound<T>(string value)
        {
            return new NotFound<T>(value);
        }

        public static implicit operator T?(NotFound<T> objectResult)
        {
            return default;
        }

        public static implicit operator NotFound<T>(Result result)
        {
            if (result.StatusCode != (int)HttpStatusCode.NotFound)
                throw new NullReferenceException("Invalid object");

            if (result.Body != null && !typeof(string).IsAssignableFrom(result.Body.GetType()))
                throw new NullReferenceException("Invalid object");

            return new NotFound<T>((string?)result.Body);
        }
    }
}
