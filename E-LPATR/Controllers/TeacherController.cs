using System;
using System.Collections.Generic;
using System.Configuration;
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
        [HttpGet]
        public ActionResult Dashboard()
        {
            if (Request.Cookies["user"]!=null)
            {
                if ((new LearningHandler().GetNumberOfProfiles(Request.Cookies["user"]["Email"])) < 5)
                {
                    ViewBag.TotalProfiles = true;
                }
                else
                {
                    ViewBag.TotalProfiles = false;
                }
                string id= Request.Cookies["user"]["Id"];
                ViewProfile vp = new ViewProfile();
                vp.Profiles = new LearningHandler().GetProfiles(int.Parse(id)).ToList();
                vp.User = new LearningHandler().GetUser(int.Parse(id));
                return View(vp);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult Display(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(new LearningHandler().GetProfile(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult EditProfile(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                ViewCreateProfile vcp = new ViewCreateProfile();
                vcp.Profile = new LearningHandler().GetProfile(Id);
          //      vcp.ProfileStatus = new LearningHandler().GetProfileStatuses().ToSelectListItems();
                
                return View(vcp);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                ViewCreateProfile vcp = new ViewCreateProfile();
                vcp.Profile = new LearnContext().Profiles.Find(Id);
                return View(vcp);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profile,ProfileStatus,SubCategory")] ViewCreateProfile viewCreate)
        {
            if (Request.Cookies["user"] != null)
            {
                if (ModelState.IsValid && Request.Cookies["user"] != null)
                {
                    string Email = Request.Cookies["user"]["Email"];
                    viewCreate.Profile.Teacher= new LearningHandler().GetUserByEmail(Email);
                   
                    //vcp.Profile.Teacher = new LearningHandler().GetUserByEmail(Request.Cookies["user"]["Email"]);
                    //vcp.ProfileStatus=new LearningHandler().GetProfileStatus(1);
                    //profile.ProfileStatus = new LearningHandler().GetProfileStatus(1);
                    //profile.Teacher = new LearningHandler().GetUserByEmail(Request.Cookies["user"]["Email"]);
                    new LearningHandler().EditProfile(viewCreate);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(Profile profile)
        {
            if(Request.Cookies["user"]!= null) { 
                 if (ModelState.IsValid && Request.Cookies["user"] != null)
                 {
                     //vcp.Profile = profile;
                     //vcp.Profile.Teacher = new LearningHandler().GetUserByEmail(Request.Cookies["user"]["Email"]);
                     //vcp.ProfileStatus=new LearningHandler().GetProfileStatus(1);
                     //profile.ProfileStatus = new LearningHandler().GetProfileStatus(1);
                     //profile.Teacher = new LearningHandler().GetUserByEmail(Request.Cookies["user"]["Email"]);
                 //    new LearningHandler().EditProfile(profile);
                     return RedirectToAction("Dashboard");
                 }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileEdit( Profile profile)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                //vcp.Profile = profile;
                //vcp.Profile.Teacher = new LearningHandler().GetUserByEmail(Request.Cookies["user"]["Email"]);
                //vcp.ProfileStatus=new LearningHandler().GetProfileStatus(1);
                //profile.ProfileStatus = new LearningHandler().GetProfileStatus(1);
                //profile.Teacher = new LearningHandler().GetUserByEmail(Request.Cookies["user"]["Email"]);
           //     new LearningHandler().EditProfile(profile);
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public ActionResult CreateProfile()
        {
            if (Request.Cookies["user"] != null)
            {
                
                    ViewCreateProfile V = new ViewCreateProfile();
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
            profile.ProfileStatus = new LearningHandler().GetProfileStatus(1);
            new LearningHandler().AddProfile(profile);
            return RedirectToAction("Dashboard");
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
        
    }
}