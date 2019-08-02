using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demo_app.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace demo_app.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private LinkGenerator _linkGenerator;

        // Constructor for our class
        public HomeController(
            ILogger<HomeController> logger,
            LinkGenerator linkGenerator
            )
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Link()
        {
            var link = _linkGenerator.GetPathByAction("Privacy", "Home");
            return Content(link);
        }

        private static User _User = new User
        {
            Username = "todd",
            Fullname = "Todd Spatafore",
            Password = "My secure password."
        };

        //[Route("Home/Privacy")]
        [HttpGet("[action]", Name ="Products_List")]
        public IActionResult Privacy()
        {
            var json = JsonConvert.SerializeObject(_User, Formatting.Indented);
            _logger.LogInformation(json);
            //throw new Exception("I'm not happy");
            //return json;
            return View(_User);
        }

        // Binding model: validates the info being passed
        [HttpPost("[action]")]
        public IActionResult Privacy(User user)
        {
            if (ModelState.IsValid)
            {
                _User.Username = user.Username;
                _User.Fullname = user.Fullname;
                _User.Password = user.Password;

                return RedirectToAction("Privacy");
            } else
            {
                return View(user);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
