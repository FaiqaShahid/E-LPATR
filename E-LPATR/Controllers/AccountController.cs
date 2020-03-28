using E_LPATR.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace E_LPATR.Controllers
{
    public class AccountController : Controller
    {
        private readonly LearningHandler lh= new LearningHandler();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View(new LearnContext().Categories.ToList());
        }
        public ActionResult Login()
        {
            if (Request.Cookies["user"] != null)
            {
                if (Request.Cookies["Role"].Value.ToString() == "Admin")
                {
                    //Session["Admin"] = user.FirstName;
                    return RedirectToAction("Home", "Admin");
                }
                else if (Request.Cookies["Role"].Value == "Teacher")
                {
                    Profile profile = new LearningHandler().GetProfile(Request.Cookies["Email"].Value);
                    if (profile != null)
                    {
                        return RedirectToAction("Home", "Teacher");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
                }
                else if (Request.Cookies["Role"].Value == "Student")
                {
                    return RedirectToAction("Home", "Student");
                }
            }
            else
            {
                return View();
            }
            return View();
        }
        public ActionResult CheckUser(string Email,string Password)
        {
            User user = lh.GetUser(Email, Password);
            if (user != null)
            {
           // Session["User"] = user;
                HttpCookie cookie = new HttpCookie("user");
                cookie["Id"] = user.Id.ToString();
                cookie["Email"] = user.Email;
                cookie["FirstName"] = user.FirstName;
                cookie["LastName"] = user.LastName;
                cookie["Role"] = user.Role.Name;
                Response.Cookies.Add(cookie);
                cookie.Expires = DateTime.Now.AddYears(1);
                if (user.Role.Name == "Admin")
                {
                    //Session["Admin"] = user.FirstName;
                    return RedirectToAction("Home", "Admin");
                }
                else if (user.Role.Name == "Teacher")
                {
                    Profile profile = new LearningHandler().GetProfile(user.Email);
                    if (profile != null)
                    {
                        return RedirectToAction("Home", "Teacher");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
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
        public ActionResult Logout()
        {
            //Session.Clear();
            //Session.Abandon();
            if (Request.Cookies["user"] != null)
            {
                Response.Cookies["user"].Expires = DateTime.Now;
            }
            //HttpCookie cookie = new HttpCookie("Preferences");
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cookie);

            return RedirectToAction("Home");
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
            user.AccountStatus = lh.GetAccountStatus(1);
            user.DateOfBirth = DateTime.Now;
            user.JoinedOn = DateTime.Now;
            user.Role = lh.GetRole(3);
            lh.AddUser(user);
            Session["User"] = user;
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
            teacher.AccountStatus = lh.GetAccountStatus(3);
            lh.AddUser(teacher);
            Session["User"] = teacher;
            return RedirectToAction("Home", "Teacher", lh.GetProfile(teacher.Email));
        }
    }
}