using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using ProjetoDDD.Apresentacao.MVC.Models;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Web.Mvc;
using System.Linq;
using SendGrid;

namespace IdentitySample.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            this.UserTokenProvider = new MyUserTokenProvider<ApplicationUser>();
            this.EmailService = new EmailService();
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = DependencyResolver.Current.GetService<ApplicationUserManager>(); 
            //var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
        //    manager.EmailService = new EmailService();
        //    manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        //Agora sim ele está dentro da classe UserManager e pode ser usado.
        //Presta atenção na hora de copiar e colar. Melhor fazer do 0 vlw
        // Metodo para login async que guarda os dados Client conectado
        public async Task<IdentityResult> SignInClientAsync(ApplicationUser user, string clientKey)
        {

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client == null)
            {
                client = new Client() { ClientKey = clientKey };
                user.Clients.Add(client);
            }

            var result = await UpdateAsync(user);
            user.CurrentClientId = client.Id.ToString();
            return result;
        }

        // Metodo para login async que remove os dados Client conectado
        public async Task<IdentityResult> SignOutClientAsync(ApplicationUser user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
            {
                throw new ArgumentNullException("clientKey");
            }

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client != null)
            {
                user.Clients.Remove(client);
            }

            user.CurrentClientId = null;
            return await UpdateAsync(user);
        }
    }
    



    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public EmailService()
        {

        }
        public Task SendAsync(IdentityMessage message)
        {
            return SendMail(message);
        }

        private Task SendMail(IdentityMessage message)
        {
            string apiKey = ConfigurationManager.AppSettings["CodSendGrid"];
            var sg = new SendGridClient(apiKey);

            var from = new EmailAddress(ConfigurationManager.AppSettings["ContaEmail"]);
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination);
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = sg.SendEmailAsync(msg);
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {
        //protected override void Seed(ApplicationDbContext context) {
        //    InitializeIdentityForEF(context);
        //    base.Seed(context);
        //}

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        //public static void InitializeIdentityForEF(ApplicationDbContext db) {
        //    //var userManager =  HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
        //    //const string name = "admin@admin.com";
        //    //const string password = "Admin@123456";
        //    //const string roleName = "Admin";

        //    ////Create Role Admin if it does not exist
        //    //var role = roleManager.FindByName(roleName);
        //    //if (role == null) {
        //    //    role = new IdentityRole(roleName);
        //    //    var roleresult = roleManager.Create(role);
        //    //}

        //    //var user = userManager.FindByName(name);
        //    //if (user == null) {
        //    //    user = new ApplicationUser { UserName = name, Email = name };
        //    //    var result = userManager.Create(user, password);
        //    //    result = userManager.SetLockoutEnabled(user.Id, false);
        //    //}

        //    //// Add user admin to Role Admin if not already added
        //    //var rolesForUser = userManager.GetRoles(user.Id);
        //    //if (!rolesForUser.Contains(role.Name)) {
        //    //    var result = userManager.AddToRole(user.Id, role.Name);
        //    //}
        //}
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}