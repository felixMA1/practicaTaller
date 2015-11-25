using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Practica2.Models;


namespace Practica2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
           
            if (Membership.ValidateUser(model.login, model.password))
            {
                //HttpContext.Application["horaLogin"] = DateTime.Now;
                //TempData["horaLogin"] = DateTime.Now;
                Session["horaLogin"] = DateTime.Now;

                FormsAuthentication.RedirectFromLoginPage(model.login,false);
                return null;

            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }


    }
}