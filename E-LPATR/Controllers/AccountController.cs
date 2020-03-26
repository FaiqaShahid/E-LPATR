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
        private LearningHandler lh= new LearningHandler();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckUser(string Email,string Password)
        {
            User user=lh.GetUser(Email, Password);
            if (user != null)
            {
                if (user.Role.Name == "Admin")
                {
                    return RedirectToAction("Home", "Admin", "user");
                }
                else if (user.Role.Name == "Teacher")
                {
                    return RedirectToAction("Home", "Teacher", lh.GetProfile(Email));
                }
                else if (user.Role.Name == "Student")
                {
                    return RedirectToAction("Home", "Student", "user");
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
            v.Countries = new LearningHandler().GetCountries().ToSelectListItems();
            return View(v);
        }
        [HttpPost]
        public ActionResult AddStudent(User user, FormCollection collection)
        {
            user.Country = lh.GetCountry(Convert.ToInt32(collection["Country"]));
            user.JoinedOn = DateTime.Now;
            user.Role = lh.GetRole(3);
            lh.AddUser(user);
            return RedirectToAction("Home","Student");
        }
        [HttpPost]
        public ActionResult AddTeacher(ViewSignUp model, FormCollection collection)
        {
            User teacher = model.User;
            teacher.Country = lh.GetCountry(Convert.ToInt32(collection["Country"]));
            teacher.JoinedOn = DateTime.Now;
            teacher.DateOfBirth = DateTime.Now;
            teacher.Role = lh.GetRole(2);
            teacher.AccountStatus = lh.GetAccountStatus(5);
            lh.AddUser(teacher);
            return RedirectToAction("Home", "Teacher");
        }
    }
}