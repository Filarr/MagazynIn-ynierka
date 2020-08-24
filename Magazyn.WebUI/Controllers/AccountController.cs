using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazyn.WebUI.Models;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Entities;
using Magazyn.Domain.Concrete;


namespace Magazyn.WebUI.Controllers
{
    public class AccountController : Controller
    {
        
        private ILoginRepository repository;

        public AccountController(ILoginRepository repo)
        {
            repository = repo ;
        }
        public ViewResult Login()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel userModel, string returnUrl)
        {
            using (EFDbContext db = new EFDbContext())
            {
                var userDetais = db.Logins.Where(x => x.User == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetais == null)
                {
                    userModel.LoginErrorMessage = "Zły login lub hasło";
                    return View("Login", userModel);
                }
                else
                {
                    Session["userID"] = userDetais.LoginID;
                    Session["userName"] = userDetais.User;
                    if (userDetais.Admin == true)
                    {
                        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    }
                    else
                    {
                        return Redirect(returnUrl ?? Url.Action("List", "Product"));
                    }
                }

            }
        }
      
       

        public ViewResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(Login login,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var userDetais = db.Logins.Where(x => x.User == login.User).FirstOrDefault();
                    if (userDetais == null)
                    {
                        repository.SaveLogin(login);
                        return View("AcceptRegister");
                    }
                    else
                    {
                        ViewBag.Message = "Proszę podać inną nazwę użytkownika";
                        return View("Register");
                    }

                }
            }
            else
            {
                return View();
            }
        }

        
            
           
    }
}