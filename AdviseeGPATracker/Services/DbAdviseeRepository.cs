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
    /// The DbAdviseeRepository class implementes the IAdviseeRepository interface to provide definitions for advisee CRUUD actions.
    /// </summary>
    public class DbAdviseeRepository : IAdviseeRepository
    {
        private AdviseeDbContext _db;
        
        /// <summary>
        /// Constructor to connect to database relational mapper LINQ
        /// </summary>
        /// <param name="db"></param>
        public DbAdviseeRepository(AdviseeDbContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Implementation of the create method to create an advisee
        /// </summary>
        /// <param name="advisee"></param>
        /// <returns>Advisee</returns>
        public Advisee Create(Advisee advisee)
        {
            _db.Advisees.Add(advisee);
            _db.SaveChanges();
            return advisee;
        }
        
        /// <summary>
        /// Implementation of the read method to find an advisee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Advisee</returns>
        public Advisee Read(int id)
        {
            return _db.Advisees.Include(p => p.Courses).FirstOrDefault(p => p.Id == id);
        }
        
        /// <summary>
        /// Implementation of the readall method to find all advisees
        /// </summary>
        /// <returns>Queryable collection of advisees</returns>
        public IQueryable<Advisee> ReadAll()
        {
            return _db.Advisees.Include(p => p.Courses);
        }

        /// <summary>
        /// Implementation of the update method to update an advisee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="advisee"></param>
        public void Update(int id, Advisee advisee)
        {
            var oldAdvisee = Read(id);
            if (oldAdvisee != null)
            {
                oldAdvisee.FirstName = advisee.FirstName;
                oldAdvisee.LastName = advisee.LastName;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Implementation of the delete method to delete an advisee
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Advisee advisee = _db.Advisees.Find(id);
            _db.Advisees.Remove(advisee);
            _db.SaveChanges();
        }
    }
}
