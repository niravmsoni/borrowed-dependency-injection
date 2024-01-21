using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DependencyInjection.Filters
{
    public class MyServiceFilterAttribute : ActionFilterAttribute
    {
        private readonly GuidService _guidService;

        public MyServiceFilterAttribute(GuidService guidService)
        {
            _guidService = guidService;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Guid",
                                                     new string[] { _guidService.Value });
            base.OnResultExecuting(context);
        }
    }
}