using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FieldController : ControllerBase
{
     private IFieldService _fieldService;
     public FieldController(IFieldService service)
     {
          _fieldService = service;
     }

     [HttpGet]
     public List<Field> GetAllFields()
     {
          return _fieldService.GetAllFields();
     }

     [HttpPost]
     public ActionResult<Field> createNewField([FromBody]Field field)
     {
          return _fieldService.CreateNewField(field);
     }

     [HttpPut]
     [Route("{id}")]
     public ActionResult<Field> UpdateProduct([FromRoute]int id, [FromBody]Field field)
     {
          try
          {
               return Ok(_fieldService.UpdateField(id, field));
          }
          catch (KeyNotFoundException e)
          {
               return NotFound("No field found at ID " + id);
          }
          catch (Exception e)
          {
               return StatusCode(500, e.ToString());
          }
     }
}