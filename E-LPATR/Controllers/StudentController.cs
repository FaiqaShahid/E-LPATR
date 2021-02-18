using E_LPATR.Models;
using E_LPATR.Models.View_Models;
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
            if (Request.Cookies["user"] != null&& Request.Cookies["user"]["Role"]=="Student"){
                return View(new LearningHandler().GetCategories()); 
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult RequestPage()
        {
            int Id = Convert.ToInt32(Session["UpdateRequestId"]);
            ViewRequest viewRequest = new ViewRequest();
            Request request = new Request();
            request=new LearningHandler().GetRequest(Id);
            viewRequest.Request = request;
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
            Session["UpdateRequestId"] = viewRequest.Request.Id;
            return RedirectToAction("RequestPage","Student");
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
                Session["UpdateRequestId"] = request.Id;
                return RedirectToAction("RequestPage");
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
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
        public ActionResult GiveReview(int Id)
        {
            if (Request.Cookies["user"] != null)
            {
                Review review = new Review();
                review.Request =new LearningHandler().GetRequest(Id);
                return View(review);
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult AddReview(FormCollection form)
        {
            if (Request.Cookies["user"] != null)
            {
                Review review = new Review();
                review.RequestId =Convert.ToInt32(form[0]);
                review.Stars = form[1].ToString();
                review.Description = form[2].ToString();
                //review.Request = new Request { Id = review.RequestId };
                review.DateTime = DateTime.Now;
                new LearningHandler().AddReview(review);
                Request request= new LearningHandler().GetRequest(review.RequestId);
                request.RequestStatusId = 4;
                request.RequestStatus = new LearningHandler().GetRequestStatus(4);
                new LearningHandler().UpdateRequest(request);
                return RedirectToAction("Home");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}