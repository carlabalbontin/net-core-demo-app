﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_app.Controllers
{
    public class BlogController : Controller
    {
        [Route("Blog/{id:int}")]
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Story(int id)
        {
            return Content(id.ToString());
        }
    }
}
