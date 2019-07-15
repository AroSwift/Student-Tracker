using AdviseeGPATracker.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviseeGPATracker.Services
{
    /// <summary>
    /// The IAdviseeRepository is an interface for the DbAdviseeRepository.
    /// </summary>
    public interface IAdviseeRepository
    {
        // Interface method for creating an advisee
        Advisee Create(Advisee advisee);
        // Interface method for getting all advisees
        IQueryable<Advisee> ReadAll();
        // Interface method for finding a single advisee
        Advisee Read(int id);
        // Interface method for updating an advisee
        void Update(int id, Advisee advisee);
        // Interface method for deleting an advisee
        void Delete(int id);
    }
}
