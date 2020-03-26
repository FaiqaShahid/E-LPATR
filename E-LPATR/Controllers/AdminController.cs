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
        LearnContext learn=  new LearnContext();
        LearningHandler lh = new LearningHandler();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        //Categories
        public ActionResult Categories()
        {
            return View(learn.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
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
            return View(learn.Issues.ToList());
        }
        public ActionResult DeleteIssues(int Id)
        {
            lh.DeleteIssue(Id);
            return RedirectToAction("Issues");
        }
        public ActionResult DetailedIssues(int Id)
        {
            Issues issue=learn.Issues.Find(Id);
            return View(issue);
        }
        //Request
        public ActionResult Requests()
        {
            return View(learn.Requests.ToList());
        }
        public ActionResult DetailedRequest(int Id)
        {
            return View(learn.Requests.Find(Id));
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
            return View(learn.Users.ToList());
        }
        public ActionResult DetailedTeacher(int Id)
        {
            return View(learn.Users.Find(Id));
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
            return View(learn.Users.ToList());
        }
        public ActionResult DetailedUser(int Id)
        {
            return View(learn.Users.Find(Id));
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
            return View(lh.GetAllTeacher());
        }
        public ActionResult DetailedTeachersRequests(int Id)
        {
            return View(learn.Users.Find(Id));
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