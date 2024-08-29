namespace MiddleWareApi.MiddleWares
{
    //This middleware will limit the request for specific api/class
    public class LimitingRequestMiddleWare
    {
        private readonly RequestDelegate _next;
        private static int _counter = 0;
        private static DateTime _lastRequest = DateTime.Now;
        public LimitingRequestMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            _counter++;
            if (DateTime.Now.Subtract(_lastRequest).Seconds > 10)
            {
                _counter = 1;
                _lastRequest = DateTime.Now;
                await _next(context);
            }
            else
            {
                if (_counter > 5)
                {
                    _lastRequest = DateTime.Now;
                    await context.Response.WriteAsync("Limit exceeded");
                }
                else
                {
                    _lastRequest = DateTime.Now;
                    await _next(context);
                }
            }
        }
    }
}
