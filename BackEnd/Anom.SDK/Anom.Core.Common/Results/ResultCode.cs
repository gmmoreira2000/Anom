namespace Anom.Core.Common.Results;

public enum ResultCode
{
    Ok = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    BusinessError = 422,
    InternalServerError = 500,
}