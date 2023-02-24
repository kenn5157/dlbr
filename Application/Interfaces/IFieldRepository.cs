using Domain;

namespace Application.Interfaces;

public interface IFieldRepository
{
    public List<Field> GetAllFields();
    public Field CreateNewField(Field field);
    public Field UpdateField(int id, Field field);
    Field GetFieldFromId(int id);
}