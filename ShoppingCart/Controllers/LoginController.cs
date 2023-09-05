using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        
        shoppingcartContext db = new shoppingcartContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.logindetails
                               where userlist.email == login.email && userlist.password == login.password
                               select new
                               {
                                   userlist.email,
                                   userlist.password,
                                   userlist.roles
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["Email"] = details.FirstOrDefault().email;
                    Session["Password"] = details.FirstOrDefault().password;
                    if (details.FirstOrDefault().roles == "Admins")
                    {
                        return RedirectToAction("Create", "Product");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return RedirectToAction("loginfailed");

                }
            }
            return View(login);
        }

        public ActionResult Search(string Searching)
        {
            return View(db.productdetails.Where(x => x.product_name.Contains(Searching) || Searching == null).ToList());
        }
    }
}