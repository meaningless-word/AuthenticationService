using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AuthenticationService
{
	public class LogMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LogMiddleware(RequestDelegate next, ILogger logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			//тут будет логика нашего Middleware
			_logger.WriteEvent("Я твой Middleware");
			_logger.WriteEvent(httpContext.Connection.RemoteIpAddress.ToString());

			await _next(httpContext);
		}
	}
}
