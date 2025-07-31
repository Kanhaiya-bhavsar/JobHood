using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobPortal.Application.Command.AddJob
{
    public class AddJobCommand:IRequest<Job>
    {
        public string? JobTitle { get; set; }

        public string? Experience { get; set; }

        public string? Ctc { get; set; }

        public string? ApplyLink { get; set; }

        public string? ApplyType { get; set; }

        public string? Location { get; set; }

        public string? Domain { get; set; }

        public string? Qualification { get; set; }

        public string? JobType { get; set; }

        public string? JobCompanyName { get; set; }

        public string? JobDescription { get; set; }

        public string? CompanyDescription { get; set; }

        public string? RolesAndResponsibility { get; set; }

        public string? EducationAndSkills { get; set; }

        public IFormFile? CompanyLogoUrl { get; set; }

        public DateTime? AddedDate { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
