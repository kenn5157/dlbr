namespace Domain;

public class Field
{
    public int Id { get; set;  }
    public string FieldName { get; set; }
    public int FieldSize { get; set; }
    public int AnimalGroupId { get; set; }
    public int AnimalCount { get; set; }
    public string CropType { get; set; }
    public string Status { get; set; }
    public DateTime LastChangeDateTime { get; set; }
}