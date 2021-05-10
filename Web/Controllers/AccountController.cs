using BL.AppServices;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppSevices;
using BL.ViewModel;


namespace Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        AccountAppService accountAppService = new AccountAppService();
        CartAppService cartAppService = new CartAppService();
        RoleAppService roleAppService = new RoleAppService();

        // GET: Account

        public ActionResult Register()
        {
            ViewBag.roles = roleAppService.GetAllRoles().Select(c => c.Name).ToList();
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            ViewBag.roles = roleAppService.GetAllRoles().Select(c => c.Name).ToList();
            if (ModelState.IsValid == false)
            {
                return View(register);
            }
            IdentityResult result = accountAppService.Register(register);
            if (result.Succeeded)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                SignInManager<ApplicationUser, string> signinmanager =
                    new SignInManager<ApplicationUser, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                ApplicationUser identityUser = accountAppService.Find(register.UserName, register.PasswordHash);
                signinmanager.SignIn(identityUser, true, true);
                CartViewModel cartViewModel = new CartViewModel() { UserID = identityUser.Id };
                cartAppService.InsertCart(cartViewModel);
                accountAppService.AssignToRole(identityUser.Id, register.Name);
                return RedirectToAction("login", "Account");
            }
            else
            {
                ModelState.AddModelError("UserName", "Username already exist");
                return View(register);
            }
        }
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid == false)
            {
                return View(login);
            }
            ApplicationUser identityUser = accountAppService.Find(login.UserName, login.PasswordHash);
            if (identityUser != null)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                SignInManager<ApplicationUser, string> signinmanager =
                    new SignInManager<ApplicationUser, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                signinmanager.SignIn(identityUser, true, true);
                //افتكره نعملها
                return RedirectToAction("Index" , "Home");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username & Password");
                return View(login);
            }
        }
        [Authorize]
        
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(string id)
        {
            return View(accountAppService.GetAccountById(id));
        }
       
        public ActionResult index()
        {
            return View(accountAppService.GetAllAccounts());
        }
        public ActionResult Details(string id)
        {
            return View(accountAppService.GetAccountById(id));
        }
        public void Delete(string id)
        {
            accountAppService.DeleteAccount(id);
        }
        public void UpdatePassword(string userID, string newPassword)
        {
            accountAppService.UpdatePassword(userID, newPassword);
        }
    }
}