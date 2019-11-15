using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_Makale.Security
{
    public class APIKeyHandler:DelegatingHandler
    {
        WebApiTestDatabaseEntities db = new WebApiTestDatabaseEntities();
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var QueryString = request.RequestUri.ParseQueryString();
            var  apiKey=QueryString["api"];
            var user = db.ApiKeys.Where(x => x.apikey1 == apiKey).FirstOrDefault();
            if (user!=null)
            {
                var princial = new ClaimsPrincipal(new GenericIdentity(user.name,"APIKey")) ;
                HttpContext.Current.User = princial;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}