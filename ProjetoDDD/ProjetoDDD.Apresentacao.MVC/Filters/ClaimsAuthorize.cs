using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoDDD.Apresentacao.MVC.Filters
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            this._claimName = claimName;
            this._claimValue = claimValue;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = HttpContext.Current.User as ClaimsPrincipal;

            //   var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
            if (user.Claims.Where(c => c.Type == _claimName)
              .Any(x => x.Value == _claimValue) || user.IsInRole("Admin"))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                        {
                                            { "action", "Error" },
                                            { "controller", "Home" }
                                        });
            }
        }

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var identity = (ClaimsIdentity)httpContext.User.Identity;

        //    var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

        //    if (claim != null)
        //    {
        //        return claim.Value == _claimValue;
        //    }

        //    return false;
        //}
    }
}