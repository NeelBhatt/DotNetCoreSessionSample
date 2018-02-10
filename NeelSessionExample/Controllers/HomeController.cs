using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NeelSessionExample.Models;
using Microsoft.AspNetCore.Http;
using NeelSessionExample.Utility;

namespace NeelSessionExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("name", "Neel Bhatt");
            HttpContext.Session.SetString("email", "neel.bhatt40@gmail.com");

            var myComplexObject = new Test();
            HttpContext.Session.SetObjectAsJson("Test", myComplexObject);

            //HttpContext.Session.SetInt32(SessionAge, 24);

            return View();
        }

        public IActionResult About()
        {
           
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Name = HttpContext.Session.GetString("name");
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.visitors = HttpContext.Session.GetInt32("visits");
            ViewBag.complex = HttpContext.Session.GetObjectFromJson<Test>("Test");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
