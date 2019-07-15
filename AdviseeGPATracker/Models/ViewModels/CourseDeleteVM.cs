using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.ViewModels
{
    public class CourseDeleteVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }
        [Display(Name = "Letter Grade")]
        public string LetterGrade { get; set; }
        public int AdviseeId { get; set; }
    }
}
