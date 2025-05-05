using Tapsi.Ordering.Application.Models;
using Tapsi.Ordering.Application.Common;
using Tapsi.Ordering.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Tapsi.Ordering.Application.ExceptionHandler;

public class ApiResponseException : Exception
{
    private ObjectResult _responseObject;
    private ResponseGenerator _responseGenerator;

    public ApiResponseException(ResponseGenerator responseGenerator)
    {
        _responseGenerator = responseGenerator;
    }

    public void SetDetail(ResponseCodes code)
    {
        _responseObject = _responseGenerator.GetResponseModel<object>(code, new { });
    }
    public void SetDetail<TModel>(ResponseCodes code, TModel Data)
    {
        _responseObject = _responseGenerator.GetResponseModel<object>(code, Data);
    }

    public ObjectResult ResponseObject
    {
        get { return _responseObject; }
    }
}