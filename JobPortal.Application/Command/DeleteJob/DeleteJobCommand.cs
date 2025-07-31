using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobPortal.Application.Command.DeleteJob
{
    public class DeleteJobCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteJobCommand(int id)
        {
            this.Id = id;   
        }
    }
}
