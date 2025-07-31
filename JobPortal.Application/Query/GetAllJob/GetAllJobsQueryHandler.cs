using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.IRepository;
using JobPortal.Domain.Models;
using MediatR;

namespace JobPortal.Application.Query.GetAllJob
{
    public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, List<Job>>
    {
        private readonly IJobRepository jobRepository;

        public GetAllJobsQueryHandler(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
        public async Task<List<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var list = await jobRepository.GetAllAsync();
            return list;
        }
    }
}
