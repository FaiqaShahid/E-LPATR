using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_LPATR.Models;
using E_LPATR.Models.View_Models;

namespace E_LPATR.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index(User user)
        {
            if (Request.Cookies["user"] != null) { 
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            ViewSignUp v = new ViewSignUp();
            v.Countries = new LearningHandler().GetCountries().ToSelectListItems();
            return View(v);
        }
        [HttpPost]
        public ActionResult Home()
        {
            if (Request.Cookies["user"]!=null)
            {
                string id= Request.Cookies["user"]["Id"];
                return View(new LearningHandler().GetProfile(int.Parse(id)));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult CreateProfile()
        {
            if (Request.Cookies["user"] != null)
            {
                ViewProfile  V= new ViewProfile();
                V.Subcategory = new LearningHandler().GetSubcategories().ToSelectListItems();
                return View(V);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult AddProfile(Profile profile,FormCollection collection)
        {
            int Id=Int32.Parse(Request.Cookies["user"]["Id"]);
            User teacher =new LearningHandler().GetUser(Id);
            profile.Teacher = teacher;
            new LearningHandler().AddProfile(profile);
            return RedirectToAction("Home",profile);
        }
        public ActionResult OrderPageTeacher()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Requests()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Profile()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}