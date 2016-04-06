using Ducode.Facts.Business;
using Ducode.Facts.Business.Enums;
using Ducode.Facts.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Ducode.Facts.Filters
{
	public class FactsExceptionFilter : ExceptionFilterAttribute
	{
		private readonly ILoggingService _loggingService = null;

		public FactsExceptionFilter(ILoggingService loggingService)
		{
			_loggingService = loggingService;
		}

		public override void OnException(HttpActionExecutedContext ctx)
		{
			string ctrlName = ctx.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
			string actionname = ctx.ActionContext.ActionDescriptor.ActionName;
			string message = string.Format("({0}Controller - {1}) {2}", ctrlName, actionname, ctx.Exception.ToString());

			bool unexpected = false;

			if (ctx.Exception is NotFoundException)
			{
				HandleRequest(ctx, HttpStatusCode.NotFound, ctx.Exception.Message);
			}
			else if (ctx.Exception is ArgumentException || ctx.Exception is ArgumentNullException)
			{
				HandleRequest(ctx, HttpStatusCode.BadRequest, ctx.Exception.Message);
			}
			else
			{
				unexpected = true;
				HandleRequest(ctx, HttpStatusCode.InternalServerError, string.Empty);
			}
			if (unexpected)
			{
				_loggingService.Log(this, LogLevel.Error, message);
			}
			else
			{
				_loggingService.Log(this, LogLevel.Warn, message);
			}
		}

		private void HandleRequest(HttpActionExecutedContext ctx, HttpStatusCode code, string message)
		{
			ctx.Response = ctx.Request.CreateResponse(code, message);
		}
	}
}