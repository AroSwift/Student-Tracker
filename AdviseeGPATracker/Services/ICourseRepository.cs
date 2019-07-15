using AdviseeGPATracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Services
{
    /// <summary>
    /// The ICourseRepository is an interface for the DbCourseRepository.
    /// </summary>
    public interface ICourseRepository
    {
        // Interface method for adding a course to an advisee
        Course Add(int adviseeId, Course course);
        // Interface method for getting all courses
        IQueryable<Course> ReadAll();
        // Interface method for getting all advisees
        IQueryable<Advisee> ReadAllAdvisees();
        // Interface method for finding a course
        Course Read(int id);
        // Interface method for finding an advisee
        Advisee ReadAdvisee(int id);
        // Interface method for updating a course
        void Update(int id, Course course);
        // Interface method for deleting a course
        void Delete(int id);
    }
}
