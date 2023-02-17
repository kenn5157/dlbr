using Infrastructure.Interfaces;

namespace Infrastructure;

public class DatabaseRepository : IDatabaseRepo
{
    private readonly DatabaseContext _dbContext;

    public DatabaseRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ??
                     throw new NullReferenceException("DatabaseContext cannot be null");
    }
    public void buildDB()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }
}