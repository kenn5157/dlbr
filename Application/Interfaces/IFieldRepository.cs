using Domain;

namespace Application.Interfaces;

public interface IFieldRepository
{
    public List<Field> GetAllFields();
    public Field CreateNewField(Field field);
    public Field UpdateField(Field field);
}