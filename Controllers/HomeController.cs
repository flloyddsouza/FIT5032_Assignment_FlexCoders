using FlexCoders_Assignment.Models;
using FlexCoders_Assignment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 *  Author Flloyd Dsouza
 */
namespace FlexCoders_Assignment.Controllers
{
    [RequireHttps]
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
            return View(new SendEmailViewModel());
        }


        // To send Email from contact Page
        [HttpPost]
        public ActionResult Contact(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String fromEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents + "Email of Person: " + fromEmail;

                    EmailSender es = new EmailSender();

                    //.Send("(FromEmail)", "(ToEmail)", subject, contents);
                    es.Send("dsouzaflloyd.11@gmail.com", "flloyd.1996@gmail.com", subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}