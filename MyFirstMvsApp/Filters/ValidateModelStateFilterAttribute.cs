namespace MyFirstMvsApp.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MyAuthorizeFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }

    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

        }
    }

    public class MyResultfilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }

    public class MyExeptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

        }
    }

    public class MyActionAttribute : ActionFilterAttribute
    {
    }  

    public class AddHeaderAttribute : Attribute, IActionFilter, IAsyncActionFilter, IAsyncPageFilter
    {
        private readonly string header;
        private readonly string value;

        public AddHeaderAttribute(string header, string value)
        {
            this.header = header;
            this.value = value;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
            ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(header, value);
            await next().ConfigureAwait(false);
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add(header, value);
            await next().ConfigureAwait(false);
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return Task.CompletedTask;
        }
    }

    public class ValidateModelStateFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new JsonResult( "Invalid model state");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           // throw new NotImplementedException();
        }
    }
}
