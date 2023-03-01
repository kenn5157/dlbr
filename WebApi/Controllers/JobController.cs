using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    public JobController(IJobService service)
    {
        _jobService = service;
    }
    
    [HttpGet]
    public List<Job> GetAllJobs()
    {
        return _jobService.GetAllJobs();
    }

    [HttpPut]
    public Job EditJob([FromBody]Job updatedJob)
    {
        return _jobService.EditJob(updatedJob);
    }

    [HttpDelete]
    public List<Job> RemoveJob(Job job)
    {
        return _jobService.RemoveJob(job);
    }
}