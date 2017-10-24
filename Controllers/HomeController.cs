using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            Zombie guy;
            try
            {
                guy = HttpContext.Session.GetObjectFromJson<Zombie>("zombie");
            }
            catch (Exception ex)
            {
                guy = new Zombie();
            }
            guy = new Zombie();
            ViewBag.fullness = guy.getFullness();
            ViewBag.happiness = guy.getHappiness();
            ViewBag.energy = guy.getEnergy();
            ViewBag.meals = guy.mealCount();
            HttpContext.Session.SetObjectAsJson("zombie", guy);
            return View(ViewBag);
        }
        [HttpPost]
        [Route("/feed")]
        public IActionResult Feed(string something)
        {
            Zombie guy = HttpContext.Session.GetObjectFromJson<Zombie>("zombie");
            guy.feed();
            HttpContext.Session.SetObjectAsJson("zombie", guy);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("/play")]
        public IActionResult Play(string something)
        {
            Zombie guy = HttpContext.Session.GetObjectFromJson<Zombie>("zombie");
            guy.play();
            HttpContext.Session.SetObjectAsJson("zombie", guy);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("/work")]
        public IActionResult Work(string something)
        {
            Zombie guy = HttpContext.Session.GetObjectFromJson<Zombie>("zombie");
            guy.work();
            HttpContext.Session.SetObjectAsJson("zombie", guy);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("/sleep")]
        public IActionResult Sleep(string something)
        {
            Zombie guy = HttpContext.Session.GetObjectFromJson<Zombie>("zombie");
            guy.sleep();
            int eng = guy.getEnergy();
            System.Console.WriteLine(eng);
            HttpContext.Session.SetObjectAsJson("zombie", guy);
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
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
    }
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            System.Console.WriteLine(value);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
        
}
