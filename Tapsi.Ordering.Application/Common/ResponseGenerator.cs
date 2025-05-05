﻿using System.Net;
using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Application.Models;
using Tapsi.Ordering.Domain.Enums;
using Microsoft.AspNetCore.Mvc;


namespace Tapsi.Ordering.Application.Common;

public class ResponseGenerator
{
    IMessageService _messageService;

    public ResponseGenerator(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public ObjectResult GetResponseModel<TData>(ResponseCodes code,Langs lang=Langs.FA)
    {
        return ResponseBuilder.Create(code).FillStatusCode().FillSuccessStatus()
            .FillMessage(_messageService,lang)
            .Build<TData>();
    }

    public ObjectResult GetResponseModel<TData>(ResponseCodes code, TData data, Langs lang=Langs.FA)
    {
        return ResponseBuilder.Create(code).FillStatusCode().FillSuccessStatus()
            .FillMessage(_messageService,lang)
            .Build(data);
    }


    class ResponseBuilder
    {
        public static IFillStatusCode Create(ResponseCodes responseCode)
        {
            return new Impl(responseCode);
        }

        public interface IBuildResponse
        {
            ObjectResult Build<TData>(TData data);
            ObjectResult Build<TData>();
        }

        public interface IFillStatusCode
        {
            IFillSuccessStatus FillStatusCode();
        }

        public interface IFillSuccessStatus
        {
            IFillMessage FillSuccessStatus();
        }

        public interface IFillMessage
        {
            IBuildResponse FillMessage(IMessageService messageService, Langs lang);
        }


        class Impl : IBuildResponse, IFillSuccessStatus, IFillMessage, IFillStatusCode
        {
            public Impl(ResponseCodes responseCode)
            {
                _responseCode = responseCode;
            }

            private ResponseCodes _responseCode;
            private int _statusCode;
            private string _message;
            private bool _isSuccess;

            public ObjectResult Build<TData>(TData data)
            {
                var body = new ApiResponseModel<TData>()
                {
                    ResultCode = _responseCode.ToString(),
                    Data = data,
                    Message = _message,
                    IsSuccess = _isSuccess,
                };
                return new ObjectResult(body)
                {
                    StatusCode = _statusCode
                };
            }

            public ObjectResult Build<TData>()
            {
                var body = new ApiResponseModel<TData>()
                {
                    Message = _message,
                    ResultCode = _responseCode.ToString()
                };
                return new ObjectResult(body)
                {
                    StatusCode = _statusCode
                };
            }

            public IFillMessage FillSuccessStatus()
            {
                switch (_responseCode)
                {
                    case 0:
                        _isSuccess = true;
                        break;
                    default:
                        _isSuccess = false;
                        break;
                }

                return this;
            }

            public IBuildResponse FillMessage(IMessageService messageService,Langs lang)
            { 
                switch (_responseCode)
                {
                    case ResponseCodes.SUCCESS: _message = messageService.GetMessage(MessageCodes.STATUS_SUCCESS,lang); break;
                    case ResponseCodes.EXCEPTION: _message = messageService.GetMessage(MessageCodes.STATUS_EXCEPTION, lang); break;
                    case ResponseCodes.VALIDATION_ERROR: _message = messageService.GetMessage(MessageCodes.STATUS_VALIDATION_ERROR, lang); break;
                }

                return this;
            }

            public IFillSuccessStatus FillStatusCode()
            {
                switch (_responseCode)
                {
                    case ResponseCodes.SUCCESS: _statusCode=(int) HttpStatusCode.OK; break;
                    case ResponseCodes.EXCEPTION: _statusCode = (int)HttpStatusCode.InternalServerError; break;
                    case ResponseCodes.VALIDATION_ERROR: _statusCode = (int)HttpStatusCode.BadRequest; break;
                }
                return this;
            }
        }
    }
}