using Domain;

namespace Application.Interfaces;

public interface IJobService
{
    public Job GetJobFromId(int jobId);
    public List<Job> GetAllJobs();
    Job UpdateJobAtId(Job updatedJob);
    List<Job> RemoveJob(Job job);
}