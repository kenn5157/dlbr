using Application.Interfaces;
using Application.Validators;
using Domain;

namespace Application;

public class FieldService : IFieldService
{

    private readonly IFieldRepository _fieldRepository;
    
    public FieldService(IFieldRepository repository)
    {
        _fieldRepository = repository ?? 
                           throw new NullReferenceException("FieldRepository is null");
    }

    public List<Field> GetAllFields()
    {
        return _fieldRepository.GetAllFields();
    }

    public Field CreateNewField(Field field)
    {
        return _fieldRepository.CreateNewField(field);
    }

    public Field CreateNewField(FieldDto dto)
    {
        throw new NotImplementedException();
    }

    public Field UpdateField(int id, Field field)
    {
        throw new NotImplementedException();
    }
}