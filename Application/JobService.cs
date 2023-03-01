using Application.Interfaces;
using Domain;

namespace Application;

public class JobService : IJobService

{

    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository repository)
    {
        _jobRepository = repository ??
                           throw new NullReferenceException("FieldRepository is null");
    }

    public Job GetJobFromId(int jobId)
    {
        return _jobRepository.GetJobFromId(jobId);
    }

    public List<Job> GetAllJobs()
    {
        return _jobRepository.GetAllJobs();
    }

    public Job UpdateJobAtId(Job updatedJob)
    {
        if (updatedJob.Id <= 0)
        {
            throw new ArgumentException();
        }
        if (string.IsNullOrEmpty(updatedJob.Name))
        {
            throw new ArgumentException();
        }
        try
        {
            return _jobRepository.UpdateAtJobId(updatedJob);
        }
        catch (System.Exception)
        {
            throw new NullReferenceException();
        }

    }

    public List<Job> RemoveJob(Job job)
    {
        return _jobRepository.RemoveJob(job);
    }

    public Job EditJob(Job updatedJob)
    {
        if (string.IsNullOrEmpty(updatedJob.Name))
        {
            throw new ArgumentException();
        }
        if (updatedJob.Id <= 0)
        {
            throw new ArgumentException();
        }
        try
        {
            var udatedJob = _jobRepository.Editjob(updatedJob);
            return updatedJob;
        }
        catch (System.Exception)
        {
            throw new NullReferenceException();
        }
    }
}