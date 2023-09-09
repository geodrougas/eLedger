using Common.Interfaces.Tools;
using Common.Models.Helper.ResultTypes;
using Common.Models.ValueTypes;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiCommon.Utils
{
    public class ResultToActionResult
    {
        public static ActionResult<T> Migrate<T>(IResult result)
            where T : class
        {
            switch(result)
            {
                case Ok<T> okResult:
                    if (okResult.Body is Unit)
                        return new OkResult();

                    return new OkObjectResult(okResult.Body);
                case NoContent<T> noContentResult:
                    return new NoContentResult();
                case NotFound<T> notFound:
                    return new NotFoundObjectResult(notFound.Body);
                case BadRequest<T> badRequest:
                    return new BadRequestObjectResult(badRequest.Body);
                case NotAuthorized<T> notAuthorized:
                    return new UnauthorizedObjectResult(notAuthorized.Body);
                default:
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}