using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Interfaces;
using Domain;
using Moq;
using WebApi.Controllers;

namespace TestProject1.ServiceTest;

public class JobsServiceTest
{

    private readonly JobController _controller;
    private readonly Mock<IJobService> _jobService;
    private readonly Mock<IJobRepository> _mockRepository;

    private readonly List<Job> jobs = new List<Job>
    {
        new Job { Id = 1, Name = "Plow Field", Description = "Plow field 30 using JD 6920."},
        new Job { Id = 2, Name = "Move Group 20", Description = "Move Group 20 from field 12 to 50."},
        new Job { Id = 3, Name = "Mix feed for Dry cows", Description = "Mix feed for dry cows, 120 cows."}
    };

    public JobsServiceTest()
    {
        _mockRepository = new Mock<IJobRepository>();
        _jobService = new Mock<IJobService>();
        _controller = new JobController(_jobService.Object);
    }

    [Fact]
    public void GetAllJobs_ShouldReturnAlljobs()
    {
        _mockRepository.Setup(repo => repo.GetAllJobs()).Returns(jobs);
        var service = new JobService(_mockRepository.Object);

        var result = service.GetAllJobs();

        Assert.NotEmpty(result);
        Assert.Equal(jobs, result);
        Assert.Equal(jobs[1], result[1]);
        Assert.NotEqual(jobs[2], result[0]);
    }

    [Fact]
    public void GetJobFromId_ShouldGetSingleJobFromId()
    {
        _mockRepository.Setup(repo => repo.GetJobFromId(1)).Returns(jobs[1]);
        var service = new JobService(_mockRepository.Object);

        var result = service.GetJobFromId(1);

        Assert.Equal(jobs[1], result);
        Assert.Equal(jobs[1].Id, result.Id);
    }

    [Fact]
    public void UpdateJobAtId()
    {
        var updatedJob = new Job { Id = 1, Name = "Muck out", Description = "Muck out calving folds at new barn" };

        _mockRepository.Setup(repo => repo.UpdateAtJobId(updatedJob)).Returns(updatedJob);

        var service = new JobService(_mockRepository.Object);

        var result = service.UpdateJobAtId(updatedJob);

        Assert.Equal(updatedJob, result);
    }

    [Fact]
    public void DeleteJobAtJob_ShouldReturnListWithoutRemovedJob()
    {
        var updatedList = jobs;
        updatedList.RemoveAt(1);

        _mockRepository.Setup(repo => repo.RemoveJob(jobs[1])).Returns(updatedList);

        var service = new JobService(_mockRepository.Object);

        var result = service.RemoveJob(jobs[1]);

        Assert.Equal(jobs[2].Id, result[1].Id);
        Assert.Equal(jobs.Count - 1, result.Count);
    }

    [Fact]
    public void EditJob()
    {
        // Given
        var job = new Job{
            Id = 1,
            Name = "New Job Name"
        };
        var newJob = new Job{
            Id = 1,
            Name = "New Job Name"
        };

        // When
        _mockRepository.Setup(repo => repo.Editjob(newJob)).Returns(() => {
            if (job.Id != newJob.Id){
                return null;
            }
            job.name = newJob.Name;
            return job;
        });
    
        // Then
        Action test = () => JobService.EditJob(newJob);
        test.
    }
}