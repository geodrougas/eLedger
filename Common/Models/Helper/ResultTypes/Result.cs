using Common.Interfaces.Tools;

namespace Common.Models.Helper.ResultTypes
{
    public class Result : IResult
    {

        public object? Body { get; init; }
        public int StatusCode { get; init; }

        public bool IsSuccess => StatusCode / 100 == 2;

        public bool IsFailure => !IsSuccess;

        public Result(object? body, int statusCode)
        {
            Body = body;
            StatusCode = statusCode;
        }

        public object? GetBody()
        {
            return Body;
        }
    }
}
