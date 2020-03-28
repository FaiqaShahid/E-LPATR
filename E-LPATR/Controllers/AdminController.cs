using E_LPATR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Controllers
{
    public class AdminController : Controller
    {
        private readonly LearnContext learn=  new LearnContext();
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
        public ActionResult AddCat(Category category, FormCollection collection)
        {
            learn.Categories.Add(category);
            learn.SaveChanges();
            return RedirectToAction("Categories");
        }
        //View
        public ActionResult CategoriesEdit(int id)
        {
            return View(lh.GetCategory(id));
        }
        //Backend
        public ActionResult EditCategories(int Id,string Name)
        {
            lh.EditCategory(Id,Name);
            return RedirectToAction("Categories");
        }
        public ActionResult CategoriesDetails(int Id)
        {
            Category category = learn.Categories.Find(Id);
            return View(category);
        }
        public ActionResult DeleteCategories(int Id)
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
            learn.Requests.Remove(learn.Requests.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Requests");
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
        public ActionResult DeleteUser(int Id)
        {
            learn.Users.Remove(learn.Users.Find(Id));
            learn.SaveChanges();
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