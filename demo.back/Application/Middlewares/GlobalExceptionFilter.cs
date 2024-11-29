
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using demo.back.Application.Utils;

namespace demo.back.Application.Middlewares
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            string message = context.Exception.Message;

            _logger.LogError(context.Exception, message);

            var errorMessage = new ApiResponse<string?>(null, EResponseCodes.Error, message);

            context.Result = new ObjectResult(errorMessage)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }

}
