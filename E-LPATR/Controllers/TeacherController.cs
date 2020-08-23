using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
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
            if (Request.Cookies["user"] != null && Request.Cookies["user"]["Role"] == "Teacher") { 
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
            if (Request.Cookies["user"]!=null && Request.Cookies["user"]["Role"] == "Teacher")
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
        public ActionResult AcceptRequest(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Request request = new LearningHandler().GetRequest(Id);
                request.RequestStatusId = 4;
                request.RequestStatus = new LearningHandler().GetRequestStatus(4);
                new LearningHandler().UpdateRequest(request);
                Earning earning = new Earning();
                earning.RequestId =Id;
                earning.TeacherId =request.Teacher.Id;
                earning.Cost =request.Cost;
                new LearningHandler().AddEarnings(earning);
                List<Earning> earnings = new LearningHandler().GetAllEarnings(Convert.ToInt32(Request.Cookies["user"]["Id"]));
                int cost = 0;
                foreach (var item in earnings)
                {
                    cost += item.Cost;
                }
                Session["TotalEarnings"] = cost;
                Session["UpdateRequestId"] = request.Id;
                return RedirectToAction("GiveReview");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult RejectRequest(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Request request = new LearningHandler().GetRequest(Id);
                request.RequestStatusId = 5;
                request.RequestStatus = new LearningHandler().GetRequestStatus(5);
                new LearningHandler().UpdateRequest(request);
                Session["UpdateRequestId"] = request.Id;
                return RedirectToAction("Issue");
            }
            return RedirectToAction("Login", "Account");
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
                vcp.Profile.Teacher = new LearningHandler().GetUser(Convert.ToInt32(Request.Cookies["user"]["Id"]));
                return View(vcp);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ViewCreateProfile viewCreate, HttpPostedFileBase file)
        {
            if (Request.Cookies["user"] != null)
            {
                if (ModelState.IsValid)
                {
                    Profile profile = viewCreate.Profile;
                    profile.ProfileStatusId = 1;
                    profile.Teacher = new LearningHandler().GetUser(Convert.ToInt32(Request.Cookies["user"]["Id"])) ;
                    profile.PackagePlan = viewCreate.Profile.PackagePlan;
                    if (file != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                            profile.Image = array;
                        }
                    }
                    new LearningHandler().EditProfile(profile);
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
                 if (ModelState.IsValid)
                 {

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
        public ActionResult AddProfile(Profile profile, HttpPostedFileBase file)
        {
            int Id=Int32.Parse(Request.Cookies["user"]["Id"]);
            User teacher =new LearningHandler().GetUser(Id);
            profile.Teacher = teacher;
            profile.ProfileStatus = new LearningHandler().GetProfileStatus(1);
            profile.SubcategoryId = 1;
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    profile.Image = array;
                }
            }
            new LearningHandler().AddProfile(profile);
            return RedirectToAction("Dashboard");
        }
        public ActionResult RequestPage()
        {
            if (Request.Cookies["user"] != null && Session["UpdateRequestId"] !=null)
            {
                ViewRequest viewRequest = new ViewRequest();
                Request request = new Request();
                request = new LearningHandler().GetRequest(Convert.ToInt32(Session["UpdateRequestId"]));
                viewRequest.Request = request;
                viewRequest.RequestMessage = new LearningHandler().GetRequestMessage(Convert.ToInt32(Session["UpdateRequestId"]));
                if (viewRequest.Request.RequestStatus.Name == "Active")
                {
                    return View(viewRequest);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AddMessage(ViewRequest viewRequest)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage = viewRequest.AddMessage;
            requestMessage.DateTime = DateTime.Now;
            requestMessage.Request = new Request { Id = viewRequest.Request.Id };
            requestMessage.Reciever = new User { Id = viewRequest.Request.Student.Id };
            requestMessage.Sender = new User { Id = Convert.ToInt32(Request.Cookies["user"]["Id"]) };
            new LearningHandler().AddMessage(requestMessage);
            Session["UpdateRequestId"] = viewRequest.Request.Id;
            return RedirectToAction("RequestPage");
        }
        public ActionResult Requests()
        {
            if (Request.Cookies["user"] != null)
            {
                List<Request> requests = new LearningHandler().GetRequestsForTeacher(Convert.ToInt32(Request.Cookies["user"]["Id"]));
                return View(requests);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult ViewRequest(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Session["UpdateRequestId"] = Id;
                return RedirectToAction("RequestPage");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult ActiveRequest(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Request request = new LearningHandler().GetRequest(Id);
                request.RequestStatusId = 2;
                request.RequestStatus = new LearningHandler().GetRequestStatus(2);
                new LearningHandler().UpdateRequest(request);
                Session["UpdateRequestId"] = request.Id;
                return RedirectToAction("RequestPage");
            }
            return RedirectToAction("Requests");
        }
        public ActionResult RemoveRequest(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Request request = new LearningHandler().GetRequest(Id);
                request.RequestStatusId = 3;
                request.RequestStatus = new LearningHandler().GetRequestStatus(3);
                new LearningHandler().UpdateRequest(request);
                Session["UpdateRequestId"] = request.Id;
                return RedirectToAction("Requests");
            }
            return RedirectToAction("Requests");
        }
    }
}