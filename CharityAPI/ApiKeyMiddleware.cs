namespace CharityAPI
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string Apikey = "XApiKey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // SignIn doesn't need API Key
            if (context.Request.Path.Value!.StartsWith("/api/SignIn/UserSignIn"))
            {
                await _next(context);
                return;
            }

            // SignUp doesn't need API Key
            if (context.Request.Path.Value!.StartsWith("/api/SignIn/UserSignUp"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(Apikey, out
                    var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(Apikey);
            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            await _next(context);
        }
    }
}
