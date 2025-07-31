using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.IRepository;
using MediatR;

namespace JobPortal.Application.Command.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, bool>
    {
        private readonly IJobRepository repository;

        public DeleteJobCommandHandler(IJobRepository repository)
        {
            this.repository = repository;
        }
        public Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var result = repository.DeleteJobAsync(request.Id);
            return result;
        }
    }
}
