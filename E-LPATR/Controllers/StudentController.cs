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
            if (Request.Cookies["user"] != null){
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult RequestPage(int Id)
        {
            ViewRequest viewRequest = new ViewRequest();
            Request request = new Request();
            request=new LearningHandler().GetRequest(Id);
            viewRequest.Request = request;
            //ViewBag.TimeString = request.DeliveryTime.ToString("MM/dd/yyyy HH:mm:ss");
            ViewBag.TimeString = request.DeliveryTime.ToString();
            viewRequest.RequestMessage = new LearningHandler().GetRequestMessage(Id);
            return View(viewRequest);
        }
        public ActionResult AddMessage(ViewRequest viewRequest)
        {
            RequestMessage requestMessage = new RequestMessage();
            requestMessage = viewRequest.AddMessage;
            requestMessage.DateTime = DateTime.Now;
            requestMessage.Request = new Request { Id = viewRequest.Request.Id };
            requestMessage.Reciever = new User { Id = viewRequest.Request.Teacher.Id };
            requestMessage.Sender= new User { Id = Convert.ToInt32(Request.Cookies["user"]["Id"]) };
            new LearningHandler().AddMessage(requestMessage);
            return RedirectToAction("RequestPage","Student");
        }
        public ActionResult RecentRequests()
        {
            if (Request.Cookies["user"] != null)
            {
                List<Request> requests = new LearningHandler().GetRequests(Convert.ToInt32(Request.Cookies["user"]["Id"]));
                return View(requests);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpGet]
        public ActionResult SentRequestRequirements(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Request request = new Request();
                request.Teacher= new LearningHandler().GetUser(Id); 
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
                request.Teacher = new User { Id = request.Teacher.Id };
                request.DateTime = DateTime.Now;
                request.Student = new User { Id = Convert.ToInt32(Request.Cookies["user"]["Id"]) };
                request.RequestStatus = new LearningHandler().GetRequestStatus(1); //Pending
                new LearningHandler().AddRequest(request);
                Session["RequestId"] = request.Id;
                return RedirectToAction("Confirmation");
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
            if (Request.Cookies["user"] != null)
            {
                if (Session["RequestId"] != null)
                {
                    return View();
                }
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult GiveReview()
        {
            return View();
        }
    }
}