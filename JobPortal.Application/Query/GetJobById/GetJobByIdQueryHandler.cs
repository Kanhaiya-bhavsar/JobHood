using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.IRepository;
using JobPortal.Domain.Models;
using MediatR;

namespace JobPortal.Application.Query.GetJobById
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Job?>
    {
        private readonly IJobRepository jobRepository;

        public GetJobByIdQueryHandler(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
        public async Task<Job?> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job= await jobRepository.GetByIdAsync(request.Id);
            if (job != null)
            {
                return job;
            }
            return null;
            
        }
    }
}
