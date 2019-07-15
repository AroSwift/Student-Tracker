using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.Entities
{
    public class AdviseeCourse
    {
        public int Id { get; set; }
        public int AdviseeId { get; set; }
        public Advisee Advisee { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int GradePoints { get; set; }
        public string LetterGrade { get; set; }
    }
}
