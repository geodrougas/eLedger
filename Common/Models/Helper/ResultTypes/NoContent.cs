using System.Net;
using Common.Interfaces.Tools;

namespace Common.Models.Helper.ResultTypes
{
    public class NoContent<T> : ObjectResult<T>, IResult
    {
        public override int StatusCode => (int)HttpStatusCode.NoContent;
        public override bool IsSuccess => true;

        public static implicit operator NoContent<T>(Result result)
        {
            if (result.StatusCode != (int)HttpStatusCode.NoContent)
                throw new NullReferenceException("Invalid object");

            return new NoContent<T>();
        }
    }
}
