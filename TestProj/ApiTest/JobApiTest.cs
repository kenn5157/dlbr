using System.Collections.Generic;
using Application.Interfaces;
using Domain;
using Moq;
using WebApi.Controllers;

namespace TestProject1.ApiTest;

public class JobApiTest
{
    private readonly JobController _controller;
    private readonly Mock<IJobRepository> _mockRepository;
    private readonly Mock<IJobService> _jobService;
    
    private readonly List<Job> jobs = new List<Job>
    {
        new Job { Id = 1, Name = "Plow Field", Description = "Plow field 30 using JD 6920."},
        new Job { Id = 2, Name = "Move Group 20", Description = "Move Group 20 from field 12 to 50."},
        new Job { Id = 3, Name = "Mix feed for Dry cows", Description = "Mix feed for dry cows, 120 cows."}
    };

    public JobApiTest()
    {
        _mockRepository = new Mock<IJobRepository>();
        _jobService = new Mock<IJobService>();
        _controller = new JobController(_jobService.Object);
    }
    
    [Fact]
    public void GetAllJobs_API_ShouldReturnAllJobs()
    {
        _jobService.Setup(service => service.GetAllJobs()).Returns(jobs);


        var result = _controller.GetAllJobs();
        
        Assert.Equal(jobs.Count, result.Count);
        Assert.Equal(jobs, result);
        Assert.Equal(jobs[1], result[1]);
    }

    [Fact]
    public void UpdateJobAtId_API_ShouldReturnNewJob()
    {
        var updatedJob = new Job { Id = 1,Name = "Muck out", Description = "Muck out calving folds at new barn" };
        
        _jobService.Setup(service => service.UpdateJobAtId(updatedJob)).Returns(updatedJob);

        var result = _controller.UpdateJobAtId(updatedJob);
        
        Assert.NotEqual(jobs[2], result);
        Assert.NotEqual(jobs[1], result);
        Assert.Equal(updatedJob, result);
    }

    [Fact]
    public void DeleteJobAtId_API_ShouldAllJobsWithoutRemovedJob()
    {
        _jobService.Setup(service => service.RemoveJob(jobs[1])).Returns(jobs);

        var result = _controller.RemoveJob(jobs[1]);
        
        
    }
}