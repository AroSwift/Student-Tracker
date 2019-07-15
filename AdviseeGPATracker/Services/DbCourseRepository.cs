using AdviseeGPATracker.DataContexts;
using AdviseeGPATracker.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Services
{
    /// <summary>
    /// The DbCourseRepository class implementes the ICourseRepository interface to provide definitions for course CRUUD actions.
    /// </summary>
    public class DbCourseRepository : ICourseRepository
    {
        private AdviseeDbContext _db;

        /// <summary>
        /// Constructor to connect to database relational mapper LINQ
        /// </summary>
        /// <param name="db"></param>
        public DbCourseRepository(AdviseeDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Implementation of the add method to create a course and then add an advisee to the course
        /// </summary>
        /// <param name="adviseeId"></param>
        /// <param name="course"></param>
        /// <returns>Course</returns>
        public Course Add(int adviseeId, Course course)
        {
            var advisee = ReadAdvisee(adviseeId);
            advisee.Courses.Add(course);
            course.Advisee = advisee;
            _db.SaveChanges();
            return course;
        }

        /// <summary>
        /// Implementation of the read method to find a single course
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Course</returns>
        public Course Read(int id)
        {
            return _db.Courses.Include(p => p.Advisee).FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Implementation of the readadvisee method to find a single advisee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Advisee</returns>
        public Advisee ReadAdvisee(int id)
        {
            return _db.Advisees.Include(p => p.Courses).FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Implementation of the readall method to get all courses
        /// </summary>
        /// <returns>Queryable collection of courses</returns>
        public IQueryable<Course> ReadAll()
        {
            return _db.Courses.Include(c => c.Advisee);
        }

        /// <summary>
        /// Implementation of the readall method to find all advisees
        /// </summary>
        /// <returns>Queryable collection of advisees</returns>
        public IQueryable<Advisee> ReadAllAdvisees()
        {
            return _db.Advisees.Include(p => p.Courses);
        }

        /// <summary>
        /// Implementation of the update method to update a single course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="course"></param>
        public void Update(int id, Course course)
        {
            var oldCourse = Read(id);
            if (oldCourse != null)
            {
                oldCourse.Code = course.Code;
                oldCourse.LetterGrade = course.LetterGrade;
                oldCourse.CreditHours = course.CreditHours;
                oldCourse.AdviseeId = course.AdviseeId;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Implementation of the delete method to delete a single course
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Course course = _db.Courses.Find(id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }
    }
}