using PruebaExceptionHandlerAPI.Attributes;
using PruebaExceptionHandlerAPI.Handlers;
using PruebaExceptionHandlerAPI.Services;
using System;
using System.Web.Http;

namespace PruebaExceptionHandlerAPI.Controllers
{
    // The attribute can be placed at Controller level if all of its methods must be monitored 
    public class HomeController : ApiController
    {
        private HomeService homeService;
        private ExceptionHandler exceptionHandler;

        public HomeController()
        {
            // Dependency Injection in a real project
            this.homeService = new HomeService();
            this.exceptionHandler = new ExceptionHandler();
        }

        // Method using the Exception Handler in catch statement
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                throw new NotImplementedException("A common exception thrown.");
            }
            catch (Exception ex)
            {
                // Another logic before handling the exception
                this.exceptionHandler.Handle(ex);
            }
            
            return Ok(new { variable = "value" });
        }

        // The attribute is placed at Method level to monitor it
        [HttpGet]
        [ExceptionHandler]
        public IHttpActionResult GetAll()
        {
            throw new Exception("A common exception thrown.");

            return Ok(new { variable = "value" });
        }

        [HttpGet]
        [ExceptionHandler]
        public IHttpActionResult GetString()
        {
            var aString = this.homeService.GetString();

            return Ok(new { variable = aString });
        }
    }
}
