using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Web.Startup1))]

namespace Web
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //createRolesandUsers();
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromDays(1),
                LoginPath = new PathString("/Account/Login")
            });
        }
        //private void createRolesandUsers()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        var user = new ApplicationUser();
        //        user.UserName = "Marwa";
        //        string userPWD = "123456";
        //        var chkUser = UserManager.Create(user, userPWD);
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = UserManager.AddToRole(user.Id, "Admin");
        //        }
        //    }

        //    if (!roleManager.RoleExists("Manager"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Manager";
        //        roleManager.Create(role);

        //    }
        //    if (!roleManager.RoleExists("User"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "User";
        //        roleManager.Create(role);

        //    }
    }
}

