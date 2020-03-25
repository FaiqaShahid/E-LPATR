using E_LPATR.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Controllers
{
    public class AccountController : Controller
    {
        private LearnContext learn = new LearnContext();
        private LeaningHelper lh = new LeaningHelper();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View(learn.Category.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckUser(string Email,string Password)
        {
            User user=lh.CheckUser(Email, Password);
            if (user != null)
            {
                if (user.Role.Name == "Admin")
                {
                    return RedirectToAction("Home", "Admin","Email");
                }
                else if (user.Role.Name == "Teacher")
                {
                    return RedirectToAction("Home", "Teacher");
                }
                else if (user.Role.Name == "Student")
                {
                    return RedirectToAction("Home", "Student");
                }
                else
                {
                    return RedirectToAction("LoginFailed");
                }
            }
            return RedirectToAction("LoginFailed");
        }
        public ActionResult LoginFailed()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            ViewSignUp v = new ViewSignUp();
            v.Countries = new LeaningHelper().GetCountries().ToSelectListItems();
            return View(v);
        }
        [HttpPost]
        public ActionResult AddStudent(User user, FormCollection collection)
        {
            user.Country = lh.GetCountry(Convert.ToInt32(collection["Country"]));
            user.JoinedOn = DateTime.Now;
            user.Role = lh.GetRole(3);
            lh.AddStudent(user);
            return RedirectToAction("Home","Student");
        }
        [HttpPost]
        public ActionResult AddTeachersRequests(TeachersRequests teacher, FormCollection collection)
        {
            teacher.Country = lh.GetCountry(Convert.ToInt32(collection["Country"]));
            teacher.JoinedOn = DateTime.Now;
            teacher.Role = lh.GetRole(4);
            teacher.AccountStatus = lh.GetAccountStatus(1);
            lh.AddTeachersRequest(teacher);
            return RedirectToAction("Home", "Teacher");
        }
    }
}