using Tapsi.Ordering.Application.ExceptionHandler;
using Tapsi.Ordering.Application.Models;
using Tapsi.Ordering.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Domain.Entities;
using System.IO;
using System;
using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Api.Filters
{

    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        Logging _loggingService;
        private ResponseGenerator _responseGenerator;
        public HttpResponseExceptionFilter(Logging loggingService, ResponseGenerator responseGenerator)
        {
            _loggingService = loggingService;
            _responseGenerator = responseGenerator;
        }
        public int Order => int.MaxValue - 10;



        public void OnException(ExceptionContext context)
        {
            var UserId = context.HttpContext.User.FindFirst("BrokerId") == null ? null : context.HttpContext.User.FindFirst("BrokerId").Value;
            var guid = context.HttpContext.Request.Headers["RequestId"];
            var rdcontroller = context.RouteData.Values["controller"] as string;
            var rdaction = context.RouteData.Values["action"] as string;
            var result = context.Result;
            var path = context.HttpContext.Request.Path.ToString();

            ApiResponseModel<object> resultBody;
            if (context.Exception is ApiResponseException ex)
            {
                if (!(rdaction.ToLower() == "Home" && rdcontroller.ToLower() == "Account"))
                {
                    _loggingService.InsertApiLog(rdcontroller, rdaction, path, guid, UserId, true, ex.ResponseObject);
                }

                context.Result = ex.ResponseObject;
            }
            else
            {
                if (!(rdaction.ToLower() == "Home" && rdcontroller.ToLower() == "Account"))
                {
                    _loggingService.InsertApiException(rdcontroller, rdaction, guid, UserId, context.Exception);
                }

                context.Result = _responseGenerator.GetResponseModel<object>(ResponseCodes.EXCEPTION);
            }

            context.ExceptionHandled = true;
        }
    }
}