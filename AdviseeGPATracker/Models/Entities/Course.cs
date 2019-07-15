using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.Entities
{
    /// <summary>
    /// Define course table structure and LINQ relational mapping to the column
    /// </summary>
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CreditHours { get; set; }
        public string LetterGrade { get; set; }
        public int AdviseeId { get; set; }
        public Advisee Advisee { get; set; }


        /// <summary>
        /// Calculate the grade point by mapping the assigned letter grade to the corresponding grade point.
        /// </summary>
        /// <returns>grade point as a double</returns>
        private double CalculateGradePoints()
        {
            switch(LetterGrade)
            {
                case "A":
                    return 4.0;
                case "A-":
                    return 3.7;
                case "B+":
                    return 3.3;
                case "B":
                    return 3.0;
                case "B-":
                    return 2.7;
                case "C+":
                    return 2.3;
                case "C":
                    return 2.0;
                case "C-":
                    return 1.7;
                case "D+":
                    return 1.3;
                case "D":
                    return 1.0;
                case "F":
                    return 0.0;
                case "U":
                    return 0.0;
                default:
                    return 0.0;
            }
        }

        /// <summary>
        /// Calculate the quality points using the formula credit hours * grade point.
        /// </summary>
        /// <returns>credit hours * grade point as a double</returns>
        public double CalculateQualityPoints()
        {
            return CreditHours * CalculateGradePoints();
        }

        public double CalculateGPA()
        {
            return CalculateQualityPoints() / CreditHours;
        }
    }

}
