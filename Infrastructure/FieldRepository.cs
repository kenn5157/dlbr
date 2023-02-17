using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class FieldRepository : IFieldRepository
{

    private readonly DatabaseContext _dbContext;

    public FieldRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ??
                     throw new NullReferenceException("DatabaseContext cannot be null");
    }
    public List<Field> GetAllFields()
    {
        return _dbContext.FieldTable.ToList();
    }

    public Field CreateNewField(Field field)
    {
        _dbContext.FieldTable.Add(field);
        _dbContext.SaveChanges();
        return field;
    }

    public Field UpdateField(Field field)
    {
        throw new NotImplementedException("ToDo: UpdateField method");
    }
}