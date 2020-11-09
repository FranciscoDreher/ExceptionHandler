using System;

namespace PruebaExceptionHandlerAPI.Services
{
    public class HomeService
    {
        public string GetString()
        {
            throw new Exception("Excepción from HomeService");

            return "value";
        }
    }
}