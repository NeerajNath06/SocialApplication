using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Enums
{
    public enum ErrorCode
    {
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        InternalServerError = 500,
        Conflict = 409,
        UnprocessableEntity = 422,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        TooManyRequests = 429,
        NotImplemented = 501,
        BadGateway = 502,
        PreconditionFailed = 412,
        UnsupportedMediaType = 415,
        RangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        Locked = 423,
        FailedDependency = 424,
        TooEarly = 425,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        RequestHeaderFieldsTooLarge = 431,
        ConcurrencyError = 505,
    }
}
