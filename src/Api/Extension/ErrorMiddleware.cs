using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Weelo.Api.Helpers;
using Weelo.Core.BaseEndpoints.Error;
using Weelo.Core.Dtos;

namespace Weelo.Api.Extension
{
    /// <summary>
    /// Errormiddleware for resilence application
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;
        JsonSerializerSettings _settings;

        /// <summary>
        /// ErrorValidation Constructor
        /// </summary>
        /// <param name="next">context application</param>
        /// <param name="logger">logger aplicacion</param>
        /// <param name="errorService">Error services</param>
        public ErrorMiddleware(
            RequestDelegate next,
            ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
           _settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        /// <summary>
        /// Invoke ErrorValidation
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Invoke context http</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation($"{context.Request.Method}: {context.Request.Path} StatusCode: {context.Response.StatusCode}");
                await _next(context);
            }
            catch (Exception exception)
            {
                await GetResult(context, exception);
            }
        }

        /// <summary>
        /// Obtienen result de la excepcion
        /// </summary>
        /// <param name="exception">Exception register</param>
        /// <param name="context">Context application</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>29/07/2021</date>
        /// <returns>void</returns>
        private async Task GetResult(HttpContext context, Exception exception)
        {
            var route = context.GetRouteData();
            string ControllerName = context.Request.Path.ToString();
            string ActionName = context.Request.Method.ToString();
            if (route != null)
            {
                try
                {
                    ControllerName = (string)route.Values["controller"];
                    ActionName = (string)route.Values["action"];
                }
                catch (Exception)
                {
                    //Todo Log this
                }
            }
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Response.ContentType = @"application/json";
            var error = CreateErrorResponse(exception, context, ControllerName, ActionName);
            var serialize = JsonConvert.SerializeObject(error, _settings);
            _logger.LogError(serialize);
            await context.Response.WriteAsync(serialize);
        }

        /// <summary>
        /// Create el error producido en la aplicacion
        /// </summary>
        /// <param name="exception">Excepcion producida</param>
        /// <param name="context">Contexto aplicado</param>
        /// <param name="ControllerName">Controlador</param>
        /// <param name="ActionName">Metodo de controlador</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>Errror Response</returns>
        private ErrorResponse CreateErrorResponse(Exception exception, HttpContext context, string controllerName, string actionName)
        {
            var user = context.Request.HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault();
            var body = ReadRequestBody.ReadRquestBodyFunction(context.Request.Body);

            var errorResponse = new ErrorResponse
            {
                ErrorDto = new ErrorDto
                {
                    ActionName = actionName,
                    ControllerName = controllerName,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    ErrorCode = context.Response.StatusCode,
                    RequestIp = context.Request.HttpContext.Connection?.LocalIpAddress?.ToString(),
                    UserId = user != null ? Guid.Parse(user.Value) : Guid.Empty,
                    Payload = JsonConvert.SerializeObject(body, _settings)
                }
            };
            return errorResponse;
        }
    }
}
