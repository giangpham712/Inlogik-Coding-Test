using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlogik.CodingTest.WebApp.Error
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new ProblemDetails();

                switch (error)
                {
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                responseModel.Title = error.Message;
                responseModel.Detail = error.Message;
                responseModel.Status = response.StatusCode;
                var result = JsonSerializer.Serialize(responseModel, responseModel.GetType());
                await response.WriteAsync(result);
            }
        }
    }
}
