using PruebaExceptionHandlerAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace PruebaExceptionHandlerAPI.Attributes
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;
            if (exception != null)
            {
                if (exception is HttpResponseException)
                {
                    return;
                }
                
                if (exception is NotImplementedException)
                {
                    actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                }
                else
                {
                    ExceptionHandling(HttpStatusCode.InternalServerError, @"Internal Server Error.");
                }
            }
            base.OnException(actionExecutedContext);
        }

        public void ExceptionHandling(HttpStatusCode statusCode, string message)
        {

            if (statusCode == HttpStatusCode.InternalServerError)
            {
                message = "Internal Server Error. Returning from Exception Handler.";
            }
            var errorResponse = new GenericErrorResponse
            {
                Message = message,
                StatusCode = ((int)statusCode).ToString()

            };
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new ObjectContent<GenericErrorResponse>(errorResponse, new JsonMediaTypeFormatter(), "application/json")
            };

            throw new HttpResponseException(response);
        }
    }
}