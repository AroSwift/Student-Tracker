using AdviseeGPATracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Models.ViewModels
{
    public class AdviseeEditVM
    {
        public int Id { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Advisee GetInstance()
        {
            return new Advisee
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
