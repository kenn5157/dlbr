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

    public Field UpdateField(int id,Field field)
    {
        // Since the ID shouldn't change, i could do this by only getitng the
        // field and getting the id by tha field instead of sending the id seperately
        var fieldToUpdate = _dbContext.FieldTable.FirstOrDefault(f => f.Id == id);

        fieldToUpdate.Name = field.Name;
        fieldToUpdate.Size = field.Size;
        fieldToUpdate.Crop = field.Crop;
        fieldToUpdate.Status = field.Status;

        _dbContext.SaveChanges();

        return field;
    }

    public Field GetFieldFromId(int id)
    {
        return _dbContext.FieldTable.FirstOrDefault(b => b.Id == id);
    }
}