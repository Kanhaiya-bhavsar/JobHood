using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.IRepository;
using JobPortal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly JobPortalDbContext db;

        public JobRepository(JobPortalDbContext db)
        {
            this.db = db;
        }
        public async Task<Job> AddJobAsync(Job job)
        {
            db.Jobs.Add(job);                 
            await db.SaveChangesAsync();      
            return job;                        
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
           var job=await db.Jobs.FirstOrDefaultAsync(x=>x.JobId == id);

            if (job != null)
            {
                db.Jobs.Remove(job);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<List<Job>> GetAllAsync()
        {
           var jobs = await db.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            var job= await db.Jobs.FirstOrDefaultAsync(x=> x.JobId == id);
            return job;
        }

        public async Task<Job?> UpdateJobAsync(int id, Job job)
        {
            var existingJob = await db.Jobs.FirstOrDefaultAsync(x => x.JobId == id);
            if (existingJob != null)
            {
                // Update all fields manually
                existingJob.JobTitle = job.JobTitle;
                existingJob.Experience = job.Experience;
                existingJob.Ctc = job.Ctc;
                existingJob.ApplyLink = job.ApplyLink;
                existingJob.ApplyType = job.ApplyType;
                existingJob.Location = job.Location;
                existingJob.Domain = job.Domain;
                existingJob.Qualification = job.Qualification;
                existingJob.JobType = job.JobType;
                existingJob.JobCompanyName = job.JobCompanyName;
                existingJob.JobDescription = job.JobDescription;
                existingJob.CompanyDescription = job.CompanyDescription;
                existingJob.RolesAndResponsibility = job.RolesAndResponsibility;
                existingJob.EducationAndSkills = job.EducationAndSkills;
                existingJob.CompanyLogoUrl = job.CompanyLogoUrl;
                existingJob.AddedDate = job.AddedDate;
                existingJob.ExpireDate = job.ExpireDate;

                await db.SaveChangesAsync(); // Save changes asynchronously
                return existingJob;
            }

            return null;
        }

    }
}
