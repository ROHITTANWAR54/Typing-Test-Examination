
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypingTestExamination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypingTestExamination.Controllers
{
    public class TypingController : Controller
    {
        private DataContext db = new DataContext();

        [Route("Typing")]
        [HttpPost]
        public IActionResult Typing(Typing Typing)
        {

            db.Typing.Add(Typing);
            db.SaveChanges();

            ViewBag.Typing = Typing;
            return View("Result");
        }
        [Route("GetResult")]
        [HttpGet]
        public IActionResult GetResult()
        {
            return View("GetResult");
        }
        [Route("GetResult")]
        [HttpPost]
        public IActionResult GetResult(int Id)
        {
            if (db.Typing.Find(Id) != null)
            {
                ViewBag.Typing = db.Typing.Find(Id);

                return View("Result");
            }
            else
            {
                ViewBag.error = "Result Not Found";
                return View("GetResult");
            }
        }

    }
}
