﻿using SheilaWard_PortfolioMVC.ViewModels;
using SheilaWard_PortfolioMVC.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SheilaWard_PortfolioMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GridDemo()
        {
            return View();
        }

        public ActionResult Add2Nums()
        {
            return View();
        }

        public ActionResult JavaScriptDemo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel email)
        {
            var from = $"{email.FromEmail}<{WebConfigurationManager.AppSettings["emailfrom"]}>";
            var mailMsg = new MailMessage(from, WebConfigurationManager.AppSettings["emailto"])
            {
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true
            };
            var svc = new PersonalEmail();
            await svc.SendAsync(mailMsg);
            return RedirectToAction("Index");
        }
    }
}