﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.ViewModels
{
    public class AdviseeListVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Total GPA")]
        public string TotalGPA { get; set; }
    }
}
