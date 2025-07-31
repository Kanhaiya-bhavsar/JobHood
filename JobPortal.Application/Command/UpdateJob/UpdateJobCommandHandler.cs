using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.IRepository;
using JobPortal.Domain.Models;
using JobPortal.Domain.Repositories;
using MediatR;

namespace JobPortal.Application.Command.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, Job>
    {
        private readonly IJobRepository jobRepository;
        private readonly IPhotoService photoService;

        public UpdateJobCommandHandler(IJobRepository jobRepository, IPhotoService photoService)
        {
            this.jobRepository = jobRepository;
            this.photoService = photoService;
        }
        public async Task<Job> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var existingJob = await jobRepository.GetByIdAsync(request.JobId);
            if (existingJob == null) return null;

            existingJob.JobTitle = request.JobTitle;
            existingJob.Experience = request.Experience;
            existingJob.Ctc = request.Ctc;
            existingJob.ApplyLink = request.ApplyLink;
            existingJob.ApplyType = request.ApplyType;
            existingJob.Location = request.Location;
            existingJob.Domain = request.Domain;
            existingJob.Qualification = request.Qualification;
            existingJob.JobType = request.JobType;
            existingJob.JobCompanyName = request.JobCompanyName;
            existingJob.JobDescription = request.JobDescription;
            existingJob.CompanyDescription = request.CompanyDescription;
            existingJob.RolesAndResponsibility = request.RolesAndResponsibility;
            existingJob.EducationAndSkills = request.EducationAndSkills;
            existingJob.AddedDate = request.AddedDate;
            existingJob.ExpireDate = request.ExpireDate;


            if (request.CompanyLogoUrl != null)
            {
                var uploadedImageUrl = await photoService.UploadImageAsync(request.CompanyLogoUrl);
                existingJob.CompanyLogoUrl = uploadedImageUrl;
            }

            return await jobRepository.UpdateJobAsync(existingJob.JobId ,existingJob);

        }
    }
}
