using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class JobRepository : IJobRepository
{
    private readonly DatabaseContext _dbContext;

    public JobRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ??
                     throw new NullReferenceException("Database context cannot be null");
    }

    public Job GetJobFromId(int jobId)
    {
        return _dbContext.JobTable.FirstOrDefault(j => j.Id == jobId);
    }

    public List<Job> GetAllJobs()
    {
        return _dbContext.JobTable.ToList();
    }

    public Job UpdateAtJobId(Job updatedJob)
    {
        _dbContext.JobTable.Update(updatedJob);
        _dbContext.SaveChanges();

        return _dbContext.JobTable.FirstOrDefault(x => x.Id == updatedJob.Id);
    }

    public List<Job> RemoveJob(Job job)
    {
        _dbContext.JobTable.Remove(job);
        _dbContext.SaveChanges();
        
        return _dbContext.JobTable.ToList();
    }
}