using E_LPATR.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using E_LPATR.Models.View_Models;

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
                if (Request.Cookies["user"]["AccountStatus"] == "Block")
                {
                    return RedirectToAction("LoginFailed", "Account");
                }
                else if (Request.Cookies["user"]["Role"] == "Admin" )
                {
                    return RedirectToAction("Home", "Admin");
                }
                else if (Request.Cookies["user"]["Role"] == "Teacher" )
                {
                    string Email = Request.Cookies["user"]["Email"];
                    Profile profile = new LearningHandler().GetProfile(Email);
                    if (profile != null)
                    {
                        return RedirectToAction("Dashboard", "Teacher");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
                }
                else if (Request.Cookies["user"]["Role"] == "Student")
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
                if (user.AccountStatus.Name == "Block")
                {
                    ViewBag.AccountStatus = "T";
                    return RedirectToAction("LoginFailed");
                }
                else { 
                    HttpCookie cookie = new HttpCookie("user");
                    string id = user.Id.ToString();
                    cookie.Values.Add("Id", id);
                    cookie.Values.Add("FirstName", user.FirstName);
                    cookie.Values.Add("LastName", user.LastName);
                    cookie.Values.Add("Email", user.Email);
                    cookie.Values.Add("Role", user.Role.Name);
                    cookie.Values.Add("AccountStatus", user.AccountStatus.Name);
                    cookie.Values.Add("Country", user.Country.Name);
                    Response.Cookies.Add(cookie);
                    cookie.Expires = DateTime.Now.AddYears(1);
                    if (user.Role.Name == "Admin" )
                    {
                        return RedirectToAction("Home", "Admin");
                    }
                    else if (user.Role.Name == "Teacher")
                    {
                        Profile profile = new LearningHandler().GetProfile(user.Email);
                        bool prof;
                        if (profile != null)
                        {
                            prof = true;
                          //  return RedirectToAction("Home", "Teacher");
                        }
                        else
                        {
                            prof = false;
                           // return RedirectToAction("Index", "Teacher");
                        }
                        ViewBag.profile = prof;
                        return RedirectToAction("Dashboard", "Teacher");
                    }
                    else if (user.Role.Name == "Student")
                    {
                        if (Session["UserId"] == null)
                        {
                            return RedirectToAction("Home", "Student","1");
                        }
                        else
                        {
                            return RedirectToAction("AllProfiles");
                        }
                    }
                    else 
                    {
                        return RedirectToAction("LoginFailed");
                    }
                }
            }
            return RedirectToAction("LoginFailed");
        }
        public ActionResult Logout()
        {
            if (Request.Cookies["user"] != null)
            {
                Response.Cookies["user"].Expires = DateTime.Now;
            }

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
        public ActionResult AddStudent(ViewSignUp Student, FormCollection collection)
        {
            User user =Student.User;
            user.Country = lh.GetCountry(Convert.ToInt32(collection["Country"]));
            user.AccountStatus = lh.GetAccountStatus(1);
            user.JoinedOn = DateTime.Now;
            user.Role = lh.GetRole(3);
            lh.AddUser(user);
            HttpCookie cookie = new HttpCookie("user");
            string id = user.Id.ToString();
            cookie.Values.Add("Id", id);
            cookie.Values.Add("FirstName", user.FirstName);
            cookie.Values.Add("LastName", user.LastName);
            cookie.Values.Add("Email", user.Email);
            cookie.Values.Add("Role", user.Role.Name);
            cookie.Values.Add("Country", user.Country.Name);
            cookie.Values.Add("AccountStatus", user.AccountStatus.Name);
            Response.Cookies.Add(cookie);
            cookie.Expires = DateTime.Now.AddYears(1);
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Home","Student");
            }
            else
            {
                return RedirectToAction("AllProfiles");
            }
        }
        [HttpPost]
        public ActionResult AddTeacher(ViewSignUp model, FormCollection collection)
        {
            User teacher = model.User;
            teacher.Country = lh.GetCountry(Convert.ToInt32(collection["Country"]));
            teacher.JoinedOn = DateTime.Now;
            teacher.Role = lh.GetRole(2);
            teacher.Degree.Name= model.User.Degree.Name;
            teacher.AccountStatus = lh.GetAccountStatus(3);
            lh.AddUser(teacher);
            HttpCookie cookie = new HttpCookie("user");
            string id = teacher.Id.ToString();
            cookie.Values.Add("Id", id);
            cookie.Values.Add("FirstName", teacher.FirstName);
            cookie.Values.Add("LastName", teacher.LastName);
            cookie.Values.Add("Email", teacher.Email);
            cookie.Values.Add("Role", teacher.Role.Name);
            cookie.Values.Add("Country", teacher.Country.Name);
            cookie.Values.Add("AccountStatus", teacher.AccountStatus.Name);
            Response.Cookies.Add(cookie);
            cookie.Expires = DateTime.Now.AddYears(1);
            return RedirectToAction("Dashboard", "Teacher");
        }
        [HttpGet]
        public ActionResult SearchedGigs(string SearchedData)
        {
            LearnContext learn = new LearnContext();
            if (SearchedData != null)
            {
                List<Profile> ProfilesByFirstName = lh.SearchByFirstName(SearchedData);
                List<Profile> ProfilesByLastName = lh.SearchByLastName(SearchedData);
                List<Profile> ProfilesByEmail = lh.SearchByEmail(SearchedData);
                List<Profile> ProfilesByCategory = lh.SearchByCategory(SearchedData);
                List<Profile> ProfilesBySubcategory = lh.SearchBySubcategory(SearchedData);
                List<Profile> profiles = new List<Profile>();
                bool p = false;
                foreach (var item in ProfilesByFirstName)
                {
                    profiles.Add(item);
                }
                foreach (var item in ProfilesByLastName)
                {
                    foreach (var profile in profiles)
                    {
                        if (profile.Description == item.Description)
                        {
                            p = true;
                        }
                    }
                    if (p == false)
                    {
                        profiles.Add(item);
                    }
                }
                p = false;
                foreach (var item in ProfilesByEmail)
                {
                    foreach (var profile in profiles)
                    {
                        if (profile.Description == item.Description)
                        {
                            p = true;
                        }
                    }
                    if (p == false)
                    {
                        profiles.Add(item);
                    }
                }
                p = false;
                foreach (var item in ProfilesByCategory)
                {
                    foreach (var profile in profiles)
                    {
                        if (profile.Description == item.Description)
                        {
                            p = true;
                        }
                    }
                    if (p == false)
                    {
                        profiles.Add(item);
                    }
                }
                p = false;
                foreach (var item in ProfilesBySubcategory)
                {
                    foreach (var profile in profiles)
                    {
                        if (profile.Description == item.Description)
                        {
                            p = true;
                        }
                    }
                    if (p == false)
                    {
                        profiles.Add(item);
                    }
                }
                if (profiles.Count!=0)
                {
                    return View(profiles);
                }
                else
                {
                    return View(lh.GetAllProfiles());
                }
            }
            return RedirectToAction("Home","Account");
        }
        public ActionResult Profile(int Id)
        {
            Profile vp = lh.GetProfile(Id);
            return View(vp);
        }
        public ActionResult AllProfiles(int Id)
        {
            if (Session["UserId"]!=null)
            {
                ViewProfile vp = new ViewProfile();
                vp.User = lh.GetUser(Id);
                vp.Profiles = lh.GetProfiles(Id);
                return View(vp);
            }
            else
            {
                User user = lh.GetUser(Convert.ToInt32(Session["UserId"]));
                ViewProfile viewprofile = new ViewProfile();
                viewprofile.User = user;
                viewprofile.Profiles = lh.GetProfiles(user.Id);
                return View(viewprofile);
            }
        }
    }
}