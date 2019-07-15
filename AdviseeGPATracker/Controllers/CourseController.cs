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
    /// CourseController provides conventional routing for all advisee CRUUD actions.
    /// </summary>
    public class CourseController : Controller
    {
        private ICourseRepository _repo;

        /// <summary>
        /// Sets instantiated ICourseRepository instance for later use. Grants access to course repository methods.
        /// </summary>
        /// <param name="repo"></param>
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Provides conventional routing for course/index.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A course add view (Create view)</returns>
        public IActionResult Add(int id)
        {
            var advisee = _repo.ReadAdvisee(id);
            if(advisee == null)
            {
                return NotFound("Could not find advisee.");
            }

            ViewData["advisee"] = _repo.ReadAdvisee(id);
            return View();
        }

        /// <summary>
        /// Provides conventional routing for a POST course/create.
        /// </summary>
        /// <param name="courseVM"></param>
        /// <returns>A view with a course add view model</returns>
        [HttpPost, ValidateAntiForgeryToken, ActionName("Add")]
        public IActionResult Create(CourseAddVM courseVM)
        {
            var course = courseVM.GetInstance();
            if (ModelState.IsValid)
            {
                _repo.Add(course.AdviseeId, course);
                return RedirectToAction("Details", "Advisee", new { id = course.AdviseeId });
            }
            return View(courseVM);
        }

        public IActionResult AddUnknownAdvisee()
        {
            ViewData["advisees"] = _repo.ReadAllAdvisees();
            return View();
        }

        /// <summary>
        /// Provides conventional routing for course/edit/<adviseeID>/<ID>.
        /// </summary>
        /// <param name="adviseeId"></param>
        /// <param name="id"></param>
        /// <returns>A edit view with a course edit view model</returns>
        public IActionResult Edit(int adviseeId, int id)
        {
            var advisee = _repo.ReadAdvisee(adviseeId);
            if (advisee == null)
            {
                return NotFound("Could not find advisee.");
            }

            var course = _repo.Read(id);
            if (course == null)
            {
                return NotFound("Could not find course.");
            }

            var courseVM = new CourseEditVM
            {
                Id = course.Id,
                Code = course.Code,
                CreditHours = course.CreditHours,
                LetterGrade = course.LetterGrade,
                AdviseeId = course.AdviseeId
            };

            return View(courseVM);
        }

        /// <summary>
        /// Provides conventional routing for the POST course/edit/<adviseeID>/<ID>.
        /// </summary>
        /// <param name="adviseeId"></param>
        /// <param name="id"></param>
        /// <param name="courseVM"></param>
        /// <returns>A redirect to advisee/details/<adviseeID> if the update is successful. Otherwise, return a view with a course edit view model.</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int adviseeId, int id, CourseEditVM courseVM)
        {
            var course = courseVM.GetInstance();
            if (ModelState.IsValid)
            {
                _repo.Update(course.Id, course);
                return RedirectToAction("Details", "Advisee", new { id = adviseeId });
            }

            return View(courseVM);
        }

        /// <summary>
        /// Provides conventional routing for course/delete/<adviseeID>/<ID>.
        /// </summary>
        /// <param name="adviseeId"></param>
        /// <param name="id"></param>
        /// <returns>A 404 if the advisee or course is not found. Otherwise, returns a delete view with a course delete view model.</returns>
        public IActionResult Delete(int adviseeId, int id)
        {
            var advisee = _repo.ReadAdvisee(adviseeId);
            if (advisee == null)
            {
                return NotFound("Could not find advisee.");
            }

            var course = _repo.Read(id);
            if (course == null)
            {
                return NotFound("Could not find course.");
            }

            var courseVM = new CourseDeleteVM
            {
                Id = course.Id,
                Code = course.Code,
                CreditHours = course.CreditHours,
                LetterGrade = course.LetterGrade,
                AdviseeId = course.AdviseeId
            };

            return View(courseVM);
        }

        /// <summary>
        /// Provides conventional routing for the POST course/delete/<adviseeID>/<ID>.
        /// </summary>
        /// <param name="adviseeId"></param>
        /// <param name="id"></param>
        /// <returns>A redirect to advisee/details/<adviseeID></returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int adviseeId, int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Details", "Advisee", new { id = adviseeId });
        }
    }
}