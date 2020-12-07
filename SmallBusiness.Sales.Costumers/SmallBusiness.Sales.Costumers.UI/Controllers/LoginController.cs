using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusiness.Sales.Costumers.BLL;
using SmallBusiness.Sales.Costumers.Model;
using SmallBusiness.Sales.Costumers.UI.Models;

namespace SmallBusiness.Sales.Costumers.UI.Controllers
{
    public class LoginController : Controller
    {
        private BusinessLogin businessLogin;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel loginVM)
        {
            try
            {
                businessLogin = new BusinessLogin();

                UserSys userSys = new UserSys
                {
                    Email = loginVM.Email,
                    Password = loginVM.Password
                };

                if (businessLogin.IsLoginValid(userSys))
                {
                    return View();
                }

                loginVM.Message = "Email/Password is not valid.";
                return View("Index", loginVM);
            }
            catch
            {
                loginVM.Message = "Email/Password is not valid.";
                return View("Index", loginVM);
            }
        }
    }
}