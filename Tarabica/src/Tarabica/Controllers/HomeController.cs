using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Tarabica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Survey()
        {
            ViewBag.ShowMessage = false;
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSurvey(string name, string comment)
        {
            SurveyResult.Save(name, comment);

            ViewBag.ShowMessage = true;
            
            return View("Survey");

            
        }

        public IActionResult SurveyResults()
        {
            using(var db = new LiteDB.LiteDatabase("db.litedb"))
            {
                ViewBag.Results =  db.GetCollection<SurveyResult>("surveyresults").FindAll().ToList();
            }   

            return View();
        }
    }
}
