using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Learning.Data;
using Learning.ViewModels;

namespace Learning.WebApi.Filters
{
    public class CustomAuthorize: AuthorizeAttribute
    {
        private const string AUTH_TOKEN = "Authorization";

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            AllowAnonymousAttribute allowAnonymousAttribute = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().FirstOrDefault();

            if (allowAnonymousAttribute != null)
            {
                return Task.FromResult<object>(null);
            }

            if (actionContext.Request.Headers.Contains(AUTH_TOKEN))
            {
                var authToken = actionContext.Request.Headers.GetValues(AUTH_TOKEN).First();
                var user = DbUtility.GetUserByToken(authToken);

                if (user != null)
                {
                    var userModel = new UserModel() { Id = user.Id, Username = user.Username, Token = authToken };
                    var principal = new UserPrincipal(userModel);
                    SetPrincipal(principal);
                    return Task.FromResult<object>(null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return Task.FromResult<object>(null);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }
        }

        private static void SetPrincipal(UserPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}