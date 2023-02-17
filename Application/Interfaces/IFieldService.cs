using Domain;

namespace Application.Interfaces;

public interface IFieldService
{
    public List<Field> GetAllFields();
    public Field CreateNewField(Field field);
    public Field UpdateField(int id, Field field);
}