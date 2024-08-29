using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MiddleWareApi.Filters
{
    public class LogSensitiveAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Sensitive action Executed !! ");
        }
        public LogSensitiveAttribute()
        {
            
        }
    }
}
