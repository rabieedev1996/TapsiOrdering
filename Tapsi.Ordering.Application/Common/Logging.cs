﻿using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Application.Models;

namespace Tapsi.Ordering.Application.Common
{
    public class Logging 
    {
        ILogService _logService;

        public Logging(ILogService logService)
        {
            _logService = logService;
        }

        public async Task InsertApiLog<TData>(string controllerName, string actionName, string path, string apiLogId, string brokerId, bool isResponse, TData data)
        {
            _logService.InsertLog("Api_Service_Log", new ApiServiceLogViewModels<TData>
            {
                ControllerName = controllerName,
                ActionName = actionName,
                BrokerId = brokerId,
                ApiData = data,
                ApiLogId = apiLogId,
                IsResponse = isResponse,
                Path = path
            });
        }
        public async Task InsertApiException(string controllerName, string actionName, string apiLogId, string brokerId, Exception ex)
        {
            _logService.InsertLog("Api_Exception_Log", new ApiExceptionLogViewModels
            {
                ControllerName = controllerName,
                ActionName = actionName,
                BrokerId = brokerId,
                Exception = ex,
                ApiLogId = apiLogId
            });
        }

        public async Task InsertLog<TData>(string Title, TData data, string categoryTitle = "GlobalLog")
        {
            _logService.InsertLog(categoryTitle, new LogViewModels<TData>
            {
                Title = Title,
                Data = data
            });
        }
    }
}
