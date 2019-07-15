using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviseeGPATracker.Models.Entities;
using AdviseeGPATracker.Models.ViewModels;
using AdviseeGPATracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdviseeGPATracker.Controllers
{
    /// <summary>
    /// AdviseeController provides conventional routing for all advisee CRUUD actions.
    /// </summary>
    public class AdviseeController : Controller
    {
        private IAdviseeRepository _repo;

        /// <summary>
        /// Sets instantiated IAdviseeRepository instance for later use. Grants access to advisee repository methods.
        /// </summary>
        /// <param name="repo"></param>
        public AdviseeController(IAdviseeRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Provides conventional routing for advisee/index.
        /// </summary>
        /// <returns>An index view with an advisee list view model</returns>
        public IActionResult Index()
        {
            var adviseeVM = _repo.ReadAll().Select(a => new AdviseeListVM
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                TotalGPA = a.CalculateTotalGPA().ToString("0.00")
            });
            return View(adviseeVM);
        }

        /// <summary>
        /// Provides conventional routing for advisee/details/<ID>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A details view with an advisee details view model</returns>
        public IActionResult Details(int id)
        {
            var advisee = _repo.Read(id);
            if (advisee == null)
            {
                return NotFound("Could not find advisee.");
            }

            var adviseeVM = new AdviseeDetailsVM
            {
                Id = advisee.Id,
                FirstName = advisee.FirstName,
                LastName = advisee.LastName,
                TotalGPA = advisee.CalculateTotalGPA().ToString("0.00"),
                Courses = advisee.Courses
            };

            return View(adviseeVM);
        }

        /// <summary>
        /// Provides conventional routing for advisee/create.
        /// </summary>
        /// <returns>A create view</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Provides conventional routing for the POST route advisee/create.
        /// </summary>
        /// <param name="adviseeVM"></param>
        /// <returns>A redirect to advisee/details if successful, otherwise, the create view with an advisee create view model</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(AdviseeCreateVM adviseeVM)
        {
            var advisee = adviseeVM.GetInstance();
            if (ModelState.IsValid)
            {
                var createdAdvisee = _repo.Create(advisee);
                return RedirectToAction("Index", "Home");
            }
            return View(adviseeVM);
        }

        /// <summary>
        /// Provides conventional routing for the POST route advisee/edit/<ID>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A advisee edit view model. If no valid advisee was specified, a 404 is returned.</returns>
        public IActionResult Edit(int id)
        {
            var advisee = _repo.Read(id);
            if (advisee == null)
            {
                return NotFound("Could not find advisee.");
            }

            var adviseeVM = new AdviseeEditVM
            {
                Id = advisee.Id,
                FirstName = advisee.FirstName,
                LastName = advisee.LastName
            };

            return View(adviseeVM);
        }

        /// <summary>
        /// Provides conventional routing for the POST route advisee/edit/<ID>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="advisee"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Advisee advisee)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(advisee.Id, advisee);
                return RedirectToAction("Index");
            }
            return View(advisee);
        }

        /// <summary>
        /// Provides conventional routing for advisee/delete/<ID>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A delete view with an advisee delete view model. If no advisee was found, a 404 is returned.</returns>
        public IActionResult Delete(int id)
        {
            var advisee = _repo.Read(id);
            if (advisee == null)
            {
                return NotFound("Could not find advisee.");
            }

            var adviseeVM = new AdviseeDeleteVM
            {
                Id = advisee.Id,
                FirstName = advisee.FirstName,
                LastName = advisee.LastName,
                TotalGPA = advisee.CalculateTotalGPA().ToString("0.00")
            };

            return View(adviseeVM);
        }

        /// <summary>
        /// Provides conventional routing for the POST route advisee/delete/<ID>. The method DeleteConfirmed handles the request though due to an override.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A redirect to home/index</returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}