using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using ProjetoDDD.Api.Models;
using ProjetoDDD.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjetoDDD.Api.App_Start
{
    public class SimpleInjectorConfiguration
    {
        public static void Inicialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            RegisterService(container);

         //   container.Register<ApplicationDbContext>(Lifestyle.Scoped);
         //   container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
         //   container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
         //   //    container.RegisterPerWebRequest<ApplicationRoleManager>();
         //   container.Register<ApplicationUserManager>(Lifestyle.Scoped);
         ////   container.Register<ApplicationSignInManager>();

            //container.Register<IAuthenticationManager>(() =>
            //          AdvancedExtensions.IsVerifying(container)
            //          ? new OwinContext(new Dictionary<string, object>()).Authentication
            //          : HttpContext.Current.GetOwinContext().Authentication);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //  container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterService(Container container)
        {
            BootStrapper.RegistraServicos(container);
        }
    }
}