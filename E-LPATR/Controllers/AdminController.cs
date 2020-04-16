using E_LPATR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Home()
        {
            if (Request.Cookies["user"] != null) {
                return View(lh.GetAllTeacher());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
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
        public ActionResult AddCat(Category category)
        {
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
        public ActionResult EditCategory([Bind(Include = "Id,Name,Image")] Category category)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                learn.Entry(category).State = EntityState.Modified;
                learn.SaveChanges();
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
        public ActionResult EditRequest([Bind(Include = "Id,Title,Description,Cost,DateTime,DeliveryTme")] Request request)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                learn.Entry(request).State = EntityState.Modified;
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
        public ActionResult DeleteTeacher(int Id)
        {
            learn.Users.Remove(learn.Users.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Teachers");
        }
        //Users
        public ActionResult Users()
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
        public ActionResult DetailedUser(int Id)
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
        public ActionResult EditUser(int? Id)
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
        public ActionResult EditUser([Bind(Include = "Id,FirstName,LastName,Email,Image,Password,DateOfBirth,JoinedOn")] User user)
        {
            if (ModelState.IsValid && Request.Cookies["user"] != null)
            {
                learn.Entry(user).State = EntityState.Modified;
                learn.SaveChanges();
                return RedirectToAction("Users");
            }
            return View("Users");
        }
        public ActionResult DeleteUser(int Id)
        {
            return View(lh.GetUser(Id));
        }
        //[HttpGet]
        //public ActionResult BlockUser(int Id)
        //{
        //    learn.Users.Remove(learn.Users.Find(Id));
        //    learn.SaveChanges();
        //    return RedirectToAction("Users");
        //}
        public ActionResult Block(int Id)
        {
            User user = lh.GetUser(Id);
            user.AccountStatus =lh.GetAccountStatus(6);
            return RedirectToAction("BlockUser");
        }
        [HttpGet]
        public ActionResult BlockUser([Bind(Include = "Id,FirstName,LastName,Email,Image,Password,DateOfBirth,JoinedOn,AccountStatus_Id")] User user)
        {
            if (Request.Cookies["user"] != null)
            {
                lh.BlockUser(user);
                return RedirectToAction("Users");
            }
            return RedirectToAction("Users");
        }
        //Request Messages
        public ActionResult TeachersRequests()
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
        public ActionResult AddTeacher(int Id)
        {
            //TeachersRequests teachers = lh.GetTeacherRequestById(Id);
            //teachers.Role = lh.GetRole(2);
            //lh.AddTeacher(teachers);
            return RedirectToAction("TeachersRequests");
        }
    }
}