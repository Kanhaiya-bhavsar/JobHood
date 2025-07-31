using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Models;
using MediatR;

namespace JobPortal.Application.Query.GetJobById
{
    public class GetJobByIdQuery:IRequest<Job?>
    {
        public int Id { get; }

        public GetJobByIdQuery(int id)
        {
            Id = id;
        }
    }
}
