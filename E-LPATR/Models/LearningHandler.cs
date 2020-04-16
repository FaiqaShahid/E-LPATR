﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Data.Entity.Migrations.Model;
using System.Security.Cryptography;

namespace E_LPATR.Models
{
    public class LearningHandler 
    {
        public Profile GetProfile(int id)
        {
            using (LearnContext lc = new LearnContext())
            {
                return lc.Profiles.Where(m => m.Teacher.Id == id)
                    .Include(m=>m.PackagePlan)
                    .Include(m => m.Teacher)
                    .Include(m => m.Teacher.Country)
                    .Include(m=>m.Teacher.Role)
                    .Include(m=>m.Teacher.AccountStatus)
                    .FirstOrDefault();

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
                        .Include(m=>m.AccountStatus)
                        .Include(m=>m.Country)
                        .Include(m=>m.Role)
                        where (u.Id == Id)
                        select u).FirstOrDefault();
            }
        }
        public void BlockUser(User user)
        {
            using (LearnContext lc = new LearnContext())
            {
                lc.Entry(user).State = EntityState.Modified;
                lc.SaveChanges();
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
                lc.Profiles.Add(profile);
                lc.SaveChanges();
            }
        }
        public Profile GetProfile(string Email)
        {
            using(LearnContext lc=new LearnContext())
            {
                return (from p in lc.Profiles
                        .Include(m => m.PackagePlan)
                        where p.Teacher.Email == Email
                        select p).FirstOrDefault();
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
        public Category EditCategory(int Id,string Name)
        {
            Category category = GetCategory(Id);
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
    }
}