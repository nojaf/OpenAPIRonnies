using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace OpenAPIRonnies
{
    public static class HttpExtensions
    {
        public static string BasePath(this ControllerBase controller) =>
            $"{controller.Request.Scheme}://{controller.Request.Host}{controller.Request.PathBase}";

        public static IActionResult CreateResponse(this ControllerBase controller, HttpStatusCode statusCode)
        {
            return controller.StatusCode((int)statusCode);
        }

        public static IActionResult CreateResponse<T>(this ControllerBase controller, HttpStatusCode statusCode,
            SwaggerResponse<T> result)
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    return controller.Ok(result.Result);
                case HttpStatusCode.Created:
                    if (result.Result is Ronny createRonny)
                    {
                        return controller.Created(new Uri($"{controller.BasePath()}/ronnies/{createRonny.Id}"), createRonny);
                    }
                    else
                    {
                        return controller.Created("", result.Result);
                    }
                case HttpStatusCode.Accepted:
                    if (result.Result is Ronny updateRonny)
                    {
                        return controller.Accepted(new Uri($"{controller.BasePath()}/ronnies/{updateRonny.Id}"), updateRonny);
                    }
                    else
                    {
                        return controller.Accepted("", result.Result);
                    }
                case HttpStatusCode.BadRequest:
                    return controller.BadRequest(result.Error);
                default:
                    return controller.StatusCode((int)statusCode);
            }
        }

        public static IActionResult CreateBadRequestFromModelState(this ControllerBase controller)
        {
            return controller.BadRequest(controller.ModelState);
        }
    }
}