using PruebaExceptionHandlerAPI.Responses;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace PruebaExceptionHandlerAPI.Handlers
{
    public class ExceptionHandler
    {
        public void Handle(Exception exception)
        {
            if (exception != null)
            {
                if (exception is HttpResponseException)
                {
                    return;
                }

                // Add if statements if you have specific definitions of Exception, like:
                // if (exception.GetType() == typeof(NotImplementedException))
                // {
                //     customHandling(...);
                // }

                this.ExceptionHandling(HttpStatusCode.InternalServerError, @"Internal Server Error.");
            }
            return;
        }

        private void ExceptionHandling(HttpStatusCode statusCode, string message)
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