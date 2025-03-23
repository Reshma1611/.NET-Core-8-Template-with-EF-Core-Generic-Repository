using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using System.Net;
using Template.BL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Template.API.Core
{

    public class InvalidModelStateHandlerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (!context.ModelState.IsValid) { 
                var data = context.ModelState.Where(x => x.Value?.Errors.Count > 0)
                    .Select(x => new FieldError(
                        x.Key,
                        x.Value?.Errors.Select(y => y.ErrorMessage).ToArray() ?? new string[] {}
                        )).ToArray();

                var resData = new ResponseData<FieldError[]>()
                {
                    Data = data
                };

                context.Result = new JsonResult(resData)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ContentType = AppCommon.CONTENT_TYPE_APPLICATION_JSON
                };
            }

            base.OnActionExecuting(context);
        }
    }
}
