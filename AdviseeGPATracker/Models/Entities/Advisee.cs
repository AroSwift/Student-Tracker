using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.Entities
{
    /// <summary>
    /// Define advisee table structure and LINQ relational mapping to the column
    /// </summary>
    public class Advisee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Advisee()
        {
            Courses = new List<Course>();
        }

        /// <summary>
        /// Calculate the total quality points by getting the sum of all associated course quality points.
        /// </summary>
        /// <returns>double</returns>
        private double CalculateTotalQualityPoints()
        {
            return Courses.Select(c => c.CalculateQualityPoints()).Sum();
        }

        /// <summary>
        /// Calculate the total credits by getting the sum of all associated course credit hours.
        /// </summary>
        /// <returns>int</returns>
        private int CalculateTotalCreditHours()
        {
            return Courses.Select(c => c.CreditHours).Sum();
        }

        /// <summary>
        /// Calculate the total GPA with the formula total quality points / credit hours. Defaults to 0.0 when no courses exist.
        /// </summary>
        /// <returns>double</returns>
        public double CalculateTotalGPA()
        {
            var creditHours = CalculateTotalCreditHours();
            return Courses.Count() == 0 ? 0.0 : CalculateTotalQualityPoints() / creditHours;
        }
    }
}
