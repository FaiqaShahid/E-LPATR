using E_LPATR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Controllers
{
    public class AdminController : Controller
    {
        private readonly LearnContext learn = new LearnContext();
        private readonly LearningHandler lh = new LearningHandler();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //Teachers Requests
        public ActionResult Home()
        {
            if (Request.Cookies["user"] != null)
            {
                return View(lh.GetAllTeacher());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DetailedTeachersRequests(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AddTeacherConfirmation(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DeleteTeachersConfirmation(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AddTeacher(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                User user = lh.GetUser(Id);
                user.AccountStatusID = 1;
                user.AccountStatus = lh.GetAccountStatus(1);
                lh.AddTeacher(user);
                return RedirectToAction("Teachers");
            }
            return RedirectToAction("TeachersRequests");
        }
        public ActionResult DeleteTeachersRequests(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                User user = lh.GetUser(Id);
                user.AccountStatusID = 5;
                user.AccountStatus = lh.GetAccountStatus(5);
                lh.DeleteTeacher(user);
                return RedirectToAction("Teachers");
            }
            return RedirectToAction("TeachersRequests");
        }
        //Categories
        public ActionResult Categories()
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Categories.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AddCategory()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult AddCat(Category category, HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    category.Image = array;
                }
            }
            learn.Categories.Add(category);
            learn.SaveChanges();
            return RedirectToAction("Categories");
        }
        //View
        [HttpGet]
        public ActionResult CategoriesEdit(int id)
        {
            return View(lh.GetCategory(id));
        }
        //Backend
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include = "Id,Name,Image")] Category category, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        category.Image = array;
                    }
                }
                lh.EditCategory(category);
                return RedirectToAction("Categories");
            }
            return View("Categories");
        }
        public ActionResult DetailedCategory(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Category category = learn.Categories.Find(Id);
                return View(category);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult DeleteCategories(int Id)
        {
            return View(lh.GetCategory(Id));
        }
        [HttpGet]
        public ActionResult CategoryDelete(int Id)
        {
            lh.DeleteCategory(Id);
            return RedirectToAction("Categories");
        }
        //Issues
        public ActionResult Issues()
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Issues.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DeleteIssues(int Id)
        {
            return View(lh.GetIssue(Id));
        }
        [HttpGet]
        public ActionResult IssueDelete(int Id)
        {
            lh.DeleteIssue(Id);
            return RedirectToAction("Issues");
        }
        public ActionResult DetailedIssues(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Issues issue = learn.Issues.Find(Id);
                return View(issue);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        //Request
        public ActionResult Requests()
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Requests.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DetailedRequest(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Requests.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DeleteRequest(int Id)
        {
            return View(learn.Requests.Find(Id));
        }
        [HttpGet]
        public ActionResult RequestDelete(int Id)
        {
            learn.Requests.Remove(learn.Requests.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Requests");
        }
        //View
        [HttpGet]
        public ActionResult RequestsEdit(int id)
        {
            return View(learn.Requests.Find(id));
        }
        //Backend
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRequest(Request request)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                Request r=learn.Requests.Find(request.Id);
                if (request.Title != null)
                {
                    r.Title = request.Title;
                }
                if (request.Describtion != null)
                {
                    r.Describtion = request.Describtion;
                }
                if (request.Cost != 0)
                {
                    r.Cost = request.Cost;
                }
                learn.Entry(r).State = EntityState.Modified;
                learn.SaveChanges();
                return RedirectToAction("Requests");
            }
            return View("Requests");
        }
        //Teacher
        public ActionResult Teachers()
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DetailedTeacher(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DeleteTeacherConfirmation(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DeleteTeacher(int Id)
        {
            learn.Users.Remove(learn.Users.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Teachers");
        }
        //Users
        public ActionResult Students()
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult DetailedStudent(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult EditStudent(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Request.Cookies["user"] != null)
            {
                
                return View(learn.Users.Find(Id));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent([Bind(Include = "Id,FirstName,LastName,Email,Image,Password,DateOfBirth,JoinedOn,AccountStatusId,RoleID")] User user)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                user.AccountStatusID = 1;
                user.RoleID = 3;
                learn.Entry(user).State = EntityState.Modified;
                learn.SaveChanges();
                return RedirectToAction("Students");
            }
            return View("Students");
        }
        public ActionResult BlockStudentConfirmation(int Id)
        {
            return View(lh.GetUser(Id));
        }
        public ActionResult BlockStudent(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                User user = lh.GetUser(Id);
                user.AccountStatusID = 6;
                user.AccountStatus = lh.GetAccountStatus(6);
                lh.BlockUser(user);
                return RedirectToAction("Students");
            }
            return RedirectToAction("Students");
        }
    }
}