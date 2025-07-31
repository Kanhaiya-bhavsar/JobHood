using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Models;
using MediatR;

namespace JobPortal.Application.Query.GetAllJob
{
    public class GetAllJobsQuery:IRequest<List<Job>>
    {
    }
}
