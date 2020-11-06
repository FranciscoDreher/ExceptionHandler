using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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