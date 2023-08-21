using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kobold.TodoApp.Api.Utils
{
    public class GlobalException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult("Ocorreu um erro")
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
