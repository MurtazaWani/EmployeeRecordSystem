using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordSystem.Application.Shared;

public class APIResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Result { get; set; }

    public APIResponse(HttpStatusCode statusCode, bool isSuccess, string message, T? result)
    {
        if((int)statusCode <= 100 || (int)statusCode >= 600)
        {
            throw new ArgumentException();
        }

        StatusCode = statusCode;
        IsSuccess = isSuccess;
        Message = message;
        Result = result;
    }
}
