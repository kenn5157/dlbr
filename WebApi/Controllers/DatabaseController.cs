using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly IDatabaseRepo _databaseRepository;

    public DatabaseController(IDatabaseRepo databaseRepo)
    {
        _databaseRepository = databaseRepo ??
                              throw new NullReferenceException("Database is null");
    }

    [HttpGet]
    public void buildDB()
    {
        _databaseRepository.buildDB();
    }
}