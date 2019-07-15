﻿using AdviseeGPATracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.ViewModels
{
    public class CourseAddVM
    {
        [Required, StringLength(50, MinimumLength = 4)]
        public string Code { get; set; }
        [Required, Range(1, 6), Display(Name = "Credit Hours")]
        public int CreditHours { get; set; }
        [Display(Name = "Letter Grade")]
        [Required, RegularExpression("^[ABCDEFU]{1}[+-]{0,1}$", ErrorMessage = "Must be a valid letter grade.")]
        public string LetterGrade { get; set; }
        [Required, Display(Name = "Advisee Name")]
        public int AdviseeId { get; set; }
        public Advisee Advisee { get; set; }

        public Course GetInstance()
        {
            return new Course
            {
                Id = 0,
                Code = Code,
                CreditHours = CreditHours,
                LetterGrade = LetterGrade,
                AdviseeId = AdviseeId
            };
        }
    }
}
