using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Interfaces;
using Domain;
using FluentAssertions;
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
    public void EditJob_JobNotInDB()
    {
        var updatedJob = new Job
        {
            Id = 4,
            Name = "Plow Field",
            Description = "Plow field 30 using JD 6920."
        };

        var service = new JobService(_mockRepository.Object);
        _mockRepository.Setup(repo => repo.Editjob(updatedJob)).Returns(() =>
        {
            try
            {
                Job job = jobs.FirstOrDefault(e => e.Id == updatedJob.Id);
                job.Name = updatedJob.Name;
                job.Description = updatedJob.Description;

                return job;
            }
            catch (System.Exception)
            {

                throw new NullReferenceException();
            }
        });

        Action test = () => service.EditJob(updatedJob);
        test.Should().Throw<NullReferenceException>();
    }

    [Fact]
    public void Editjob_JobIdInvalid()
    {
        var editJob = new Job
        {
            Id = -1,
            Name = "Plow Field",
            Description = "Plow field 30 using JD 6920."
        };

        var service = new JobService(_mockRepository.Object);

        Action test = () => service.EditJob(editJob);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditJob_NameEmpty()
    {
        var editJob = new Job
        {
            Id = -1,
            Name = "",
            Description = "Plow field 30 using JD 6920."
        };

        var service = new JobService(_mockRepository.Object);

        Action test = () => service.EditJob(editJob);
        test.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void EditJob_ObjectOk()
    {
        var updatedJob = new Job
        {
            Id = 1,
            Name = "Updated job",
            Description = "Updated Description"
        };

        var service = new JobService(_mockRepository.Object);
        _mockRepository.Setup(repo => repo.Editjob(updatedJob)).Returns(() =>
        {
            try
            {
                Job job = jobs.FirstOrDefault(e => e.Id == updatedJob.Id);
                job.Name = updatedJob.Name;
                job.Description = updatedJob.Description;

                return job;
            }
            catch (System.Exception)
            {

                throw new NullReferenceException();
            }
        });

        var result = service.EditJob(updatedJob);
        Assert.Equal(updatedJob, result);
    }
}