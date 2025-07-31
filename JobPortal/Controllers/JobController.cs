using JobPortal.Application.Command.AddJob;
using JobPortal.Application.Command.DeleteJob;
using JobPortal.Application.Command.UpdateJob;
using JobPortal.Application.Query.GetAllJob;
using JobPortal.Application.Query.GetJobById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJob()
        {
            var list = await mediator.Send(new GetAllJobsQuery());
            return Ok(list);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id) {
            var obj=await mediator.Send(new GetJobByIdQuery(id));
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var obj = await mediator.Send(new DeleteJobCommand(id));
            if (obj == true)
            {
                return Ok(obj);
            }
            return BadRequest();

        }
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromForm] AddJobCommand job)
        {
            if (job == null)
                return BadRequest("job cannot be null");

            var result = await mediator.Send(job);
            return CreatedAtAction(nameof(GetJobById), new { id = result?.JobId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromForm] UpdateJobCommand job)
        {
            if (job == null || job.JobId != id)
                return BadRequest("Expense ID mismatch");

            var job1 = await mediator.Send(new GetJobByIdQuery(job.JobId));
            if (job1 == null)
                return NotFound();

            var updated = await mediator.Send(job);
            return Ok(updated);
        }

    }
}
