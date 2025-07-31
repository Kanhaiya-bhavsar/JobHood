using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Models;

namespace JobPortal.Domain.IRepository
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync();
        Task<Job?> GetByIdAsync(int id);
        Task<Job> AddJobAsync(Job job);           // returns full created object
        Task<Job?> UpdateJobAsync(int id, Job job); // returns updated object or null
        Task<bool> DeleteJobAsync(int id);        // just success/fail
    }
}
