using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace E_LPATR.Models
{
    public class LeaningHelper 
    {
        public void AddStudent(User user)
        {
            using(LearnContext lc = new LearnContext())
            {
                lc.Entry(user.Country).State = EntityState.Unchanged;
                lc.Entry(user.Role).State = EntityState.Unchanged;
                lc.User.Add(user);
                lc.SaveChanges();
            }
        }
        public void AddTeacher(TeachersRequests teacher)
        {
            using (LearnContext lc = new LearnContext())
            {
                lc.Entry(teacher.Role).State = EntityState.Unchanged;
                
                //    Teacher t = new Teacher();

                //    t.TeacherRequests.Email = teacher.Email;
                //    t.TeacherRequests.FirstName=teacher.FirstName;
                //    t.TeacherRequests.LastName = teacher.LastName;
                //    t.TeacherRequests.Password = teacher.Password;
                //    t.TeacherRequests.Country.Id = teacher.Country.Id;
                //    t.TeacherRequests.Role.Id = teacher.Role.Id;
                //    t.TeacherRequests.AccountStatus.Id = teacher.AccountStatus.Id;
                //    t.TeacherRequests.CV= teacher.CV;
                //    t.TeacherRequests.Education = teacher.Education;
                //    t.TeacherRequests.JoinedOn = teacher.JoinedOn;
                lc.User.Add(teacher);
                lc.SaveChanges();
            }
        }
        public void AddTeachersRequest(TeachersRequests teacher)
        {
            using(LearnContext lc = new LearnContext())
            {
                lc.Entry(teacher.Country).State = EntityState.Unchanged;
                lc.Entry(teacher.Role).State = EntityState.Unchanged;
                lc.Entry(teacher.AccountStatus).State = EntityState.Unchanged;
                lc.TeachersRequests.Add(teacher);
                lc.SaveChanges();
            }
        }
        public User CheckUser(string Email,string Password)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from u in lc.User
                        .Include(m => m.Role)
                        .Include(m => m.Country)
                        where (u.Email == Email &&
                        u.Password == Password)
                        select u
                        ).FirstOrDefault();
                        
            }
        }
        public List<Country> GetCountries()
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.country
                        select c
                        ).ToList();
            }
        }
        public Country GetCountry(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.country
                        where c.Id == id
                        select c
                        ).FirstOrDefault();
            }
        }
        public Role GetRole(int id)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from r in lc.Role
                        where r.Id == id
                        select r).FirstOrDefault();
            }
        }
        public AccountStatus GetAccountStatus(int Id)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from s in lc.AccountStatus
                        where s.Id==Id
                        select s).FirstOrDefault();
            }
        }
        public Category EditCategory(int Id,string Name)
        {
            Category category = GetCategory(Id);
            using (LearnContext lc = new LearnContext())
            {
                Category c = (from s in lc.Category
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
                Category category = lc.Category.Find(Id);
                lc.Category.Remove(category);
                lc.SaveChanges();
            }
        }
        public Category GetCategory(int Id)
        {
            using (LearnContext lc=new LearnContext())
            {
                return (from c in lc.Category
                        where c.Id == Id
                        select c).FirstOrDefault();
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
        public TeachersRequests GetTeacherRequestById(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return (from c in lc.TeachersRequests
                        where c.Id == id
                        select c
                        ).FirstOrDefault();
            }
        }
    }
}