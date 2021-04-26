using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using System.Threading.Tasks;

namespace DependencyInjection.Filters
{
    public class ResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Do something before the action executes.
            Debug.WriteLine(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
            // next() calls the action method.
            context.HttpContext.Response.Headers.Add("Author", new string[] { "Abdul Rahman" });
            var resultContext = await next();
            // resultContext.Result is set.
            // Do something after the action executes.
            Debug.WriteLine(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }
    }
}
