using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loggin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Aysegul's Pastry Blog.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The name of this blog is Cakerella .";

            return View();
        }

       
        public ActionResult Contact()
        {
            ViewBag.Message = "This is a blog which is created for Web Technologies Class Project.";

            return View();
        }
        
        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Table t)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (MyDbEntities dc = new MyDbEntities())
                {
                    var v = dc.Tables.Where(a => a.UserName.Equals(t.UserName) && a.Password.Equals(t.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();

                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(t);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
