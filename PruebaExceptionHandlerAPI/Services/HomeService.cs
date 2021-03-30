using System;

namespace PruebaExceptionHandlerAPI.Services
{
    public class HomeService
    {
        public string GetString()
        {
            throw new Exception("Exception from HomeService");

            return "value";
        }
    }
}
