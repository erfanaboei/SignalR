using System;
using System.Linq;
using LabelPrintingEF.Application.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Application.Utilities
{
    public class RequestResult
    {
        public bool IsSuccess { get; set; }
        public RequestResultStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public Object Result { get; set; }
        public RequestResult(bool isSuccess, RequestResultStatusCode statusCode, string message = null, string data = null, object result = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
            Data = data;
            Result = result;
        }


        #region Implicit Operators

        public static implicit operator RequestResult(OkResult result)
        {
            return new RequestResult(true, RequestResultStatusCode.Success);
        }

        public static implicit operator RequestResult(BadRequestResult result)
        {
            return new RequestResult(false, RequestResultStatusCode.BadRequest);
        }

        public static implicit operator RequestResult(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new RequestResult(false, RequestResultStatusCode.BadRequest, message);
        }

        public static implicit operator RequestResult(ContentResult result)
        {
            return new RequestResult(true, RequestResultStatusCode.Success, result.Content);
        }

        public static implicit operator RequestResult(NotFoundResult result)
        {
            return new RequestResult(false, RequestResultStatusCode.NotFound);
        }

        #endregion
    }

}
