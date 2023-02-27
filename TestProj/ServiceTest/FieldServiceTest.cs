using System.Collections.Generic;
using Application;
using Application.Interfaces;
using Domain;
using Moq;

namespace TestProject1.ServiceTest;

public class FieldServiceTest
{

    [Fact]
    public void GetAllfields_ShouldReturnAllFields()
    {
        var fieldRepositoryMock = new Mock<IFieldRepository>();
        var fields = new List<Field>
        {
            new Field{ Id = 1, Name = "Field One", Size =  30, Crop = "Grass", Status = "Status" },
            new Field{ Id = 2, Name = "Field Two", Size =  15, Crop = "Grass", Status = "Status" },
            new Field{ Id = 3, Name = "Field Three", Size =  45, Crop = "Grain", Status = "Status" },
        };

        fieldRepositoryMock.Setup(repo => repo.GetAllFields()).Returns(fields);
        var service = new FieldService(fieldRepositoryMock.Object);

        var result = service.GetAllFields();

        Assert.NotEmpty(result);
        Assert.Equal(fields, result);
    }
}