using System.Net;
using Common.Interfaces.Tools;

namespace Common.Models.Helper.ResultTypes
{
    public class NotAuthorized<T> : ObjectResult<T>, IResult
    {
        private string? _message;
        public override string? Message => _message;
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;
        public override bool IsSuccess => false;
        public NotAuthorized(string? message)
        {
            _message = message;
        }

        public static implicit operator NotAuthorized<T>(string value)
        {
            return new NotAuthorized<T>(value);
        }

        public static implicit operator T?(NotAuthorized<T> objectResult)
        {
            return default;
        }

        public static implicit operator NotAuthorized<T>(Result result)
        {
            if (result.StatusCode != (int)HttpStatusCode.Unauthorized)
                throw new NullReferenceException("Invalid object");

            if (result.Body != null && !typeof(string).IsAssignableFrom(result.Body.GetType()))
                throw new NullReferenceException("Invalid object");

            return new NotAuthorized<T>((string?)result.Body);
        }
    }
}
