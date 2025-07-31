using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.IRepository;
using JobPortal.Domain.Models;
using JobPortal.Domain.Repositories;
using MediatR;

namespace JobPortal.Application.Command.AddJob
{
    public class AddJobCommandHandler : IRequestHandler<AddJobCommand, Job>
    {
        private readonly IJobRepository jobRepository;
        private readonly IPhotoService photoService;

        public AddJobCommandHandler(IJobRepository jobRepository, IPhotoService photoService)
        {
            this.jobRepository = jobRepository;
            this.photoService = photoService;
        }
        public async Task<Job> Handle(AddJobCommand request, CancellationToken cancellationToken)
        {
            string uploadedImageUrl = null;

            // 🖼 Upload image if provided
            if (request.CompanyLogoUrl != null)
            {
                uploadedImageUrl = await photoService.UploadImageAsync(request.CompanyLogoUrl);

            }

            var job = new Job
            {
                JobTitle = request.JobTitle,
                Experience = request.Experience,
                Ctc = request.Ctc,
                ApplyLink = request.ApplyLink,
                ApplyType = request.ApplyType,
                Location = request.Location,
                Domain = request.Domain,
                Qualification = request.Qualification,
                JobType = request.JobType,
                JobCompanyName = request.JobCompanyName,
                JobDescription = request.JobDescription,
                CompanyDescription = request.CompanyDescription,
                RolesAndResponsibility = request.RolesAndResponsibility,
                EducationAndSkills = request.EducationAndSkills,
                CompanyLogoUrl = uploadedImageUrl, // ✅ Assign uploaded logo URL after saving image
                AddedDate = request.AddedDate ?? DateTime.UtcNow, // optional default
                ExpireDate = request.ExpireDate
            };

            var result= await jobRepository.AddJobAsync(job);
            return result;
        }
    }
}
