
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypingTestExamination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TypingTestExamination.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {
            var _admin = db.Account.Where(s => s.Email == Email);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password ==Password).Any())
                {
                    HttpContext.Session.SetString("Email",Email);

                    ViewBag.Account = db.Account.Find(4003);
                    return View("Profile");
                }
                else
                {
                    ViewBag.errorPassword = "Wrong Password";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.errorEmail = "Wrong Email";
                return View("Login");
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Index");
        }


        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(Account Account)
        {
            db.Account.Add(Account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("aboutus")]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }
        [Route("contactus")]
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }
        [Route("adminlogin")]
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View("AdminLogin");
        }
        [Route("adminlogin")]
        [HttpPost]
        public IActionResult AdminLogin(Admin Admin)
        {
            var _admin =db.Admin.Where(s=>s.Email==Admin.Email);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password == Admin.Password).Any())
                {
                   
                        HttpContext.Session.SetString("AdminEmail", Admin.Email);

                        return View("AdminPanal");
                }
                else
                {
                    ViewBag.errorPassword = "Invalid Password";
                    return View("AdminLogin");
                }
            }
            else
            {
                ViewBag.errorEmail = "Invalid Email";
                return View("AdminLogin");
            }
        }
        [Route("delete")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [Route("delete")]
        [HttpPost]
        public IActionResult Delete(int Rollno)
        {
            if (db.Account.Find(Rollno) != null)
            {
                db.Account.Remove(db.Account.Find(Rollno));
                db.SaveChanges();
                ViewBag.delete = "Record is deleted";
                return View();
            }
            else
            {
                ViewBag.delete = "Record is Not Available in Database";
                return View();

            }
        }
        [Route("Viewall")]
        [HttpGet]
        public IActionResult Viewall()
        {
            ViewBag.Account = db.Account.ToList();
            return View("Viewall");
        }
        [Route("update1")]
        [HttpGet]
        public IActionResult Update1()
        {
            return View("Update1");
        }
        [Route("update2")]
        [HttpPost]
        public IActionResult Update2(int id)
        {
            ViewBag.Account = db.Account.Find(id);
            return View("Update2");
        }
       [Route("update3")]
        [HttpPost]
        public IActionResult Update3(Account account)
        {
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.update = "Record Updated";
            return View("Update2");
        }
        [Route("AdminLogout")]
        [HttpGet]
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Remove("AdminEmail");
            return RedirectToAction("AdminLogin");
        }
    }
}