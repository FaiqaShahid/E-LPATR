using E_LPATR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult OrderPage()
        {
            return View();
        }
        public ActionResult RecentOrders()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SentRequestRequirements(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Request request = new Request();
                request.Teacher= new LearningHandler().GetUser(Id);
                //ViewRequest vr = new ViewRequest();
                //vr.user = new LearningHandler().GetUser(Id);
                return View(request);
            }
            else
            {
                Session["UserId"] = Id;
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AddRequirements(Request request)
        {
            if (Request.Cookies["user"] != null)
            {
                int cost = request.Cost;
                Payment payment = new Payment();
                payment.PaidVia = "HBL";
                payment.Cost = cost;
                payment.DateTime = DateTime.Now;
                payment.PaymentStatus = new LearningHandler().GetPaymentStatus(1);//Recieved
                request.Payment = payment;
                //request.Payment.Cost = cost;
                //request.Payment.DateTime = DateTime.Now;
                //request.Payment.PaidVia = "HBL";
                //request.Payment.PaymentStatus = new LearningHandler().GetPaymentStatus(1);
                request.Teacher = new User { Id = request.Teacher.Id };
                request.DateTime = DateTime.Now;
                request.Student = new User { Id = Convert.ToInt32(Request.Cookies["user"]["Id"]) };
                request.RequestStatus = new LearningHandler().GetRequestStatus(1); //Pending
                
                new LearningHandler().AddRequest(request);
                return View(request);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult Confirmation()
        {
            Request request = new LearnContext().Requests.LastOrDefault();
            return View(request);
        }
        public ActionResult GiveReview()
        {
            return View();
        }
    }
}