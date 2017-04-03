using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace EpisodeWebservice.Exception
{
    public class GlobalExceptionHandler: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            //We can log this exception message to the file or database.  
           
            var response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                new
                {
                    error = "Could not decode request: JSON parsing failed"
                });
            actionExecutedContext.Response = response;
        }
    }
}