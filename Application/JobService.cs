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
        return _jobRepository.UpdateAtJobId(updatedJob);
    }

    public List<Job> RemoveJob(Job job)
    {
        return _jobRepository.RemoveJob(job);
    }
}