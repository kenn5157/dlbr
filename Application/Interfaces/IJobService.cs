using Domain;

namespace Application.Interfaces;

public interface IJobService
{
    public Job GetJobFromId(int jobId);
    public List<Job> GetAllJobs();
    public Job EditJob(Job updatedJob);
    List<Job> RemoveJob(Job job);
}