using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClinic_DB.Models;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
namespace MyClinic_DB.Controllers
{
    [AllowAnonymous]
   
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            using (var context = new ClinicDB())
            {
                
                bool isValid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password );
                
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return RedirectToAction("Index","Home");
                }
               
             
                ModelState.AddModelError("", "Invalid username or password");
               
            }
            return View( );
        }
        // GET: Login
        public ActionResult SignUp( )
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult SignUp(Users model)
        {
            using(var context= new ClinicDB() )
            {
                var check = context.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();
                if(check!= null)
                {
                    ModelState.AddModelError("", "Username Already Exists");
                    return View(model);
                }
               

               context.Users.Add(model);
                context.SaveChanges();
               
            }
            return RedirectToAction("Login");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}