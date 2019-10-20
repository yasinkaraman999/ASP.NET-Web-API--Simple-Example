using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi_Makale.Filters
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            response.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = response;
            base.OnException(actionExecutedContext);


        }
    }
}