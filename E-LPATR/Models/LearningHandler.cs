using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Data.Entity.Migrations.Model;
using System.Security.Cryptography;
using System.Data.Entity.Infrastructure;
using E_LPATR.Models.View_Models;

namespace E_LPATR.Models
{
    public class LearningHandler 
    {
        #region search
        public List<Profile> SearchByFirstName(string Name)
        {
            using(LearnContext lc=new LearnContext())
            {
                return lc.Profiles.Where(m => m.Teacher.LastName.Contains(Name)&& m.Teacher.AccountStatus.Name=="Active")
                        .Include(m => m.PackagePlan)
                        .Include(m => m.Teacher)
                        .Include(m => m.Teacher.Country)
                        .Include(m => m.Teacher.Role)
                        .Include(m => m.Teacher.AccountStatus)
                        .ToList();
            }
        }
        public List<Profile> SearchByLastName(string Name)
        {
            using(LearnContext lc=new LearnContext())
            {
                return lc.Profiles.Where(m => m.Teacher.LastName.Contains(Name) && m.Teacher.AccountStatus.Name == "Active")
                        .Include(m => m.PackagePlan)
                        .Include(m => m.Teacher)
                        .Include(m => m.Teacher.Country)
                        .Include(m => m.Teacher.Role)
                        .Include(m => m.Teacher.AccountStatus)
                        .ToList();
            }
        }
        public List<Profile> SearchByEmail(string Email)
        {
            using(LearnContext lc=new LearnContext())
            {
                return lc.Profiles.Where(m => m.Teacher.Email.Contains(Email) && m.Teacher.AccountStatus.Name == "Active")
                        .Include(m => m.PackagePlan)
                        .Include(m => m.Teacher)
                        .Include(m => m.Teacher.Country)
                        .Include(m => m.Teacher.Role)
                        .Include(m => m.Teacher.AccountStatus)
                        .ToList();
            }
        }
        public List<Profile> SearchByCategory(string Category)
        {
            using(LearnContext lc=new LearnContext())
            {
                return lc.Profiles.Where(m => m.Subcategory.Category.Name.Contains(Category) && m.Teacher.AccountStatus.Name == "Active")
                        .Include(m => m.PackagePlan)
                        .Include(m => m.Teacher)
                        .Include(m => m.Teacher.Country)
                        .Include(m => m.Teacher.Role)
                        .Include(m => m.Teacher.AccountStatus)
                        .ToList();
            }
        }
        public List<Profile> SearchByName(string Name)
        {
            using (LearnContext lc = new LearnContext())
            {
                return lc.Profiles.Where(m => m.Name.Contains(Name) && m.Teacher.AccountStatus.Name == "Active")
                        .Include(m => m.PackagePlan)
                        .Include(m => m.Teacher)
                        .Include(m => m.Teacher.Country)
                        .Include(m => m.Teacher.Role)
                        .Include(m => m.Teacher.AccountStatus)
                        .ToList();
            }
        }
        public List<Profile> SearchBySubcategory(string Subcategory)
        {
            using(LearnContext lc=new LearnContext())
            {
                return lc.Profiles.Where(m => m.Name.Contains(Subcategory) && m.Teacher.AccountStatus.Name == "Active")
                        .Include(m => m.PackagePlan)
                        .Include(m => m.Teacher)
                        .Include(m => m.Teacher.Country)
                        .Include(m => m.Teacher.Role)
                        .Include(m => m.Teacher.AccountStatus)
                        .ToList();
            }
        }
        public List<Profile> GetAllProfiles()
        {
            using (LearnContext lc = new LearnContext())
            {
                return lc.Profiles
                    .Include(m => m.PackagePlan)
                    .Include(m => m.ProfileStatus)
                    //.Include(m => m.Category)
                    //.Include(m => m.Category.Subcategory)
                    .Include(m => m.Teacher)
                    .Include(m => m.Teacher.Country)
                    .Include(m => m.Teacher.Role)
                    .Include(m => m.Teacher.AccountStatus)
                    .ToList();
            }
        }
        #endregion
        public Profile GetProfile(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return lc.Profiles.Where(m => m.Id== id)
                    .Include(m=>m.PackagePlan)
                    .Include(m => m.Teacher)
                    .Include(m => m.Teacher.Country)
                    .Include(m=>m.Teacher.Role)
                    .Include(m=>m.Teacher.AccountStatus)
                    .FirstOrDefault();

            }
        }
        public List<Profile> GetProfiles(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return lc.Profiles.Where(m => m.Teacher.Id == id)
                    .Include(m=>m.PackagePlan)
                    .Include(m=>m.ProfileStatus)
                    //.Include(m=>m.Category.Subcategory)
                   // .Include(m=>m.Category)
                    .Include(m => m.Teacher)
                    .Include(m => m.Teacher.Country)
                    .Include(m=>m.Teacher.Role)
                    .Include(m=>m.Teacher.AccountStatus)
                    .ToList();

            }
        }
        public List<RequestMessage> GetRequestMessage(int Id)
        {
            using (LearnContext lc=new LearnContext())
            {
                return (from rm in lc.RequestMessages
                        .Include(m => m.Reciever)
                        .Include(m => m.Sender)
                        where rm.Request.Id == Id
                        select rm)
                        .ToList();
            }
        }
        #region User
        public void AddUser(User user)
        {
            using (LearnContext lc = new LearnContext())
            {
                lc.Entry(user.Country).State = EntityState.Unchanged;
                lc.Entry(user.Role).State = EntityState.Unchanged;
                lc.Entry(user.AccountStatus).State = EntityState.Unchanged;
                lc.Users.Add(user);
                lc.SaveChanges();
            }
        }
        public User GetUser(string Email, string Password)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Users
                        .Include(a => a.AccountStatus)
                        .Include(c => c.Country)
                        .Include(r => r.Role)
                        where u.Email == Email && u.Password == Password
                        select u).FirstOrDefault();
            }
        }
        public Request GetRequest(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Requests
                        .Include(u => u.Payment)
                        .Include(u => u.RequestStatus)
                        .Include(u => u.Student)
                        .Include(u => u.Teacher)
                        where u.Id == Id
                        select u).FirstOrDefault();
            }
        }
        public List<Request> GetRequests(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Requests
                        .Include(u => u.Payment)
                        .Include(u => u.RequestStatus)
                        .Include(u => u.Student)
                        .Include(u => u.Teacher)
                        where u.Student.Id == Id
                        select u).ToList();
            }
        }
        public List<Request> GetRequestsForTeacher(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Requests
                        .Include(u => u.Payment)
                        .Include(u => u.RequestStatus)
                        .Include(u => u.Student)
                        .Include(u => u.Teacher)
                        where u.Teacher.Id == Id
                        select u).ToList();
            }
        }
        public User GetUserByEmail(string Email)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Users
                        .Include(m=>m.AccountStatus)
                        .Include(m=>m.Country)
                        .Include(m=>m.Role)
                        where (u.Email == Email)
                        select u).FirstOrDefault();
            }
        }
        public User GetUser(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Users
                        .Include(m => m.AccountStatus)
                        .Include(m => m.Country)
                        .Include(m => m.Role)
                        .Include(m => m.Degree)
                        where (u.Id == Id)
                        select u)
                        .FirstOrDefault();
            }
        }
        public User GetUserId(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Users
                        where (u.Id == Id)
                        select u)
                        .FirstOrDefault();
            }
        }
        public void BlockUser(User user)
        {
            
            using (LearnContext lc = new LearnContext())
            {
                try
                {
                    lc.Entry(user.AccountStatus).State = EntityState.Modified;
                    lc.Entry(user).State = EntityState.Modified;
                    lc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex) {
                    ex.Entries.Single().Reload();
                }
            }
        }
        public void EditProfile(Profile profile)
        {
            using (LearnContext lc = new LearnContext())
            {
                try
                {
                    Profile profile1 = lc.Profiles.Find(profile.Id);
                    profile1.Description = profile.Description;
                    profile1.Image = profile.Image;
                    profile1.PackagePlan.CostPer3Days = profile.PackagePlan.CostPer3Days;
                    profile1.PackagePlan.CostPerDay = profile.PackagePlan.CostPerDay;
                    profile1.PackagePlan.CostPerHour = profile.PackagePlan.CostPerHour;
                    profile1.Name = profile.Name;
                    lc.Entry(profile1.PackagePlan).State = EntityState.Modified;
                    //lc.Entry(profile.Subcategory).State = EntityState.Modified;
                    lc.Entry(profile1).State = EntityState.Modified;
                    lc.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
               
            }
        }
        public void AddTeacher(User user)
        {
            using (LearnContext lc = new LearnContext())
            {
                try
                {
                    lc.Entry(user.AccountStatus).State = EntityState.Modified;
                    lc.Entry(user).State = EntityState.Modified;
                    lc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex) {
                    ex.Entries.Single().Reload();
                }
            }
        }
        public void AddEarnings(Earning earning)
        {
            using (LearnContext lc = new LearnContext())
            {
                lc.Earnings.Add(earning);
                lc.SaveChanges();
            }
        }
        public void UpdateRequest(Request request)
        {

            using (LearnContext lc = new LearnContext())
            {
                try
                {
                    lc.Entry(request.RequestStatus).State = EntityState.Modified;
                    lc.Entry(request).State = EntityState.Modified;
                    lc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                }
            }
        }
        public void DeleteTeacher(User user)
        {
            
            using (LearnContext lc = new LearnContext())
            {
                try
                {
                    lc.Entry(user.AccountStatus).State = EntityState.Modified;
                    lc.Entry(user).State = EntityState.Modified;
                    lc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex) {
                    ex.Entries.Single().Reload();
                }
            }
        }
        public List<User> GetAllTeacher()
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from u in lc.Users
                        .Include(m=>m.AccountStatus)
                        .Include(m=>m.Country)
                        .Include(m=>m.Role)
                        .Include(m=>m.Degree)
                        where u.AccountStatus.Name=="Pending"
                        select u).ToList();
            }
        }
        #endregion
        public void AddProfile(Profile profile)
        {
            using(LearnContext lc=new LearnContext())
            {
                lc.Entry(profile.Teacher).State = EntityState.Unchanged;
                lc.Entry(profile.ProfileStatus).State = EntityState.Unchanged;
                lc.Profiles.Add(profile);
                lc.SaveChanges();
            }
        }
        public List<Earning> GetAllEarnings(int Id)
        {
            using (LearnContext lc=new LearnContext())
            {
                return (from e in lc.Earnings
                        where e.TeacherId == Id
                        select e).ToList();
            }
        }
        public void AddMessage(RequestMessage requestMessage)
        {
            using(LearnContext lc=new LearnContext())
            {
                lc.Entry(requestMessage.Sender).State = EntityState.Unchanged;
                lc.Entry(requestMessage.Reciever).State = EntityState.Unchanged;
                lc.Entry(requestMessage.Request).State = EntityState.Unchanged;
                lc.RequestMessages.Add(requestMessage);
                lc.SaveChanges();
            }
        }
        public Profile GetProfile(string Email)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from p in lc.Profiles
                        .Include(m => m.PackagePlan)
                        .Include(m => m.ProfileStatus)
                        where p.Teacher.Email == Email
                        select p).FirstOrDefault();
            }
        }
        public int GetNumberOfProfiles(string Email)
        {
            using (LearnContext lc=new LearnContext())
            {
                return (from p in lc.Profiles
                        .Include(m => m.PackagePlan)
                        .Include(m => m.ProfileStatus)
                        where p.Teacher.Email == Email
                        select p
                        ).Count();

            }
        }
        public List<Country> GetCountries()
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.Countries
                        select c
                        ).ToList();
            }
        }
        public List<Category> GetCategories()
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.Categories
                        select c
                        ).ToList();
            }
        }
        public List<ProfileStatus> GetProfileStatuses()
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from p in lc.ProfileStatus
                        select p
                        ).ToList();
            }
        }
        
        public Country GetCountry(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.Countries
                        where c.Id == id
                        select c
                        ).FirstOrDefault();
            }
        }
        public ProfileStatus GetProfileStatus(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.ProfileStatus
                        where c.Id == id
                        select c
                        ).FirstOrDefault();
            }
        }
        public RequestStatus GetRequestStatus(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.RequestStatuses
                        where c.Id == id
                        select c
                        ).FirstOrDefault();
            }
        }
        public void AddRequest(Request request)
        {
            using (LearnContext lc=new LearnContext())
            {
                lc.Entry(request.RequestStatus).State = EntityState.Unchanged;
                lc.Entry(request.Student).State = EntityState.Unchanged;
                lc.Entry(request.Teacher).State = EntityState.Unchanged;
                lc.Requests.Add(request);
                lc.SaveChanges();
            }
        }
        public PaymentStatus GetPaymentStatus(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.PaymentStatuses
                        where c.Id == id
                        select c
                        ).FirstOrDefault();
            }
        }
        public Issues GetIssue(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from i in lc.Issues
                        where i.Id == id
                        select i
                        ).FirstOrDefault();
            }
        }
        public Role GetRole(int id)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from r in lc.Roles
                        where r.Id == id
                        select r).FirstOrDefault();
            }
        }
        public AccountStatus GetAccountStatus(int Id)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from s in lc.AccountStatuses
                        where s.Id==Id
                        select s).FirstOrDefault();
            }
        }
        public List<Subcategory> GetSubcategories()
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.Subcategories
                        select c
                        ).ToList();
            }
        }
        public AccountStatus GetSubcategory(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from s in lc.AccountStatuses
                        where s.Id == Id
                        select s).FirstOrDefault();
            }
        }
        public Category EditCategory(Category category)
        {
            //Category category = GetCategory(Id);
            using (LearnContext lc = new LearnContext())
            {
                Category c = (from s in lc.Categories
                             where s.Id == category.Id
                             select s).FirstOrDefault();
                c.Name = category.Name;
                c.Image = category.Image;
                lc.SaveChanges();
                return c;
            }
        }
        public void DeleteCategory(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                Category category = lc.Categories.Find(Id);
                lc.Categories.Remove(category);
                lc.SaveChanges();
            }
        }
        public void DeleteIssue(int Id)
        {
            using (LearnContext lc = new LearnContext())
            {
                Issues issues = lc.Issues.Find(Id);
                lc.Issues.Remove(issues);
                lc.SaveChanges();
            }
        }
        public Category GetCategory(int Id)
        {
            using (LearnContext lc=new LearnContext())
            {
                return (from c in lc.Categories
                        where c.Id == Id
                        select c).FirstOrDefault();
            }
        }
        public Category SearchCategory(string Data)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.Categories
                        where Data == c.Name
                        select c).FirstOrDefault();
            }
        }
        public Subcategory SearchSubCategory(string Data)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from sc in lc.Subcategories
                        where Data == sc.Name
                        select sc).FirstOrDefault();
            }
        }
        public List<User> SearchTeacher(string Data)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from t in lc.Users
                        where Data == t.FirstName ||Data==t.LastName||Data==t.Email
                        select t).ToList();
            }
        }
        public void AddReview(Review review)
        {
            using (LearnContext lc=new LearnContext())
            {
                lc.Entry(review.Request).State = EntityState.Unchanged;
                lc.Reviews.Add(review);
                lc.SaveChanges();
            }
        }
        public void ModifyUser(User user)
        {
            using (LearnContext lc=new LearnContext())
            {
                User u = lc.Users.Find(user.Id);
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Password = user.Password;
                u.AccountStatusID = user.AccountStatusID;
                lc.SaveChanges();
            }
        }
        public void AddIssue(Issues issue)
        {
            using (LearnContext lc = new LearnContext())
            {   
                lc.Issues.Add(issue);
                lc.SaveChanges();
            }
        }
    }
}