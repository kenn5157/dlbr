using Domain;

namespace Application.Interfaces;

public interface IJobRepository
{
    public Job GetJobFromId(int jobId);
    public List<Job> GetAllJobs();
    Job UpdateAtJobId(Job updatedJob);
    List<Job> RemoveJob(Job job);
    Job Editjob(Job updatedJob);
}