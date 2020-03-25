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
        LeaningHelper lh = new LeaningHelper();
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
            return View(learn.Category.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCat(Category category, FormCollection collection)
        {
            learn.Category.Add(category);
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
            Category category = learn.Category.Find(Id);
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
            return View(learn.Request.ToList());
        }
        public ActionResult DetailedRequest(int Id)
        {
            return View(learn.Request.Find(Id));
        }
        public ActionResult DeleteRequest(int Id)
        {
            learn.Request.Remove(learn.Request.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Requests");
        }
        //Teacher
        public ActionResult Teachers()
        {
            return View(learn.Teachers.ToList());
        }
        public ActionResult DetailedTeacher(int Id)
        {
            return View(learn.Teachers.Find(Id));
        }
        public ActionResult DeleteTeacher(int Id)
        {
            learn.Teachers.Remove(learn.Teachers.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Teachers");
        }
        //Users
        public ActionResult Users()
        {
            return View(learn.User.ToList());
        }
        public ActionResult DetailedUser(int Id)
        {
            return View(learn.User.Find(Id));
        }
        public ActionResult DeleteUser(int Id)
        {
            learn.User.Remove(learn.User.Find(Id));
            learn.SaveChanges();
            return RedirectToAction("Users");
        }

        //Request Messages
        public ActionResult TeachersRequests()
        {
            return View(learn.TeachersRequests.ToList());
        }
        public ActionResult DetailedTeachersRequests(int Id)
        {
            return View(learn.TeachersRequests.Find(Id));
        }
        public ActionResult AddTeacher(int Id)
        {
            TeachersRequests teachers = lh.GetTeacherRequestById(Id);
            teachers.Role = lh.GetRole(2);
            lh.AddTeacher(teachers);
            return RedirectToAction("TeachersRequests");
        }
    }
}