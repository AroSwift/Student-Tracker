using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdviseeGPATracker.Models;

namespace AdviseeGPATracker.Controllers
{
    /// <summary>
    /// HomeController provides conventional routing for the home/index and home/developer routes
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Provides conventional routing for home/index.
        /// </summary>
        /// <returns>Redirect to advisee/index</returns>
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Advisee");
        }

        /// <summary>
        /// Provides conventional routing for home/developer.
        /// </summary>
        /// <returns>A view called developer</returns>
        public IActionResult Developer()
        {
            return View();
        }
    }
}
