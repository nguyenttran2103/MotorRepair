using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorRepair.ApplicationServices.Abstracts;
using MotorRepair.Models;
using MotorRepair.Models.Messaging;
using System.Reflection.Metadata.Ecma335;

namespace MotorRepair.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WorkItemsController : ControllerBase
  {
    private readonly IWorkItemService _workItemsService;

    public WorkItemsController(IWorkItemService workItemsService) {
      _workItemsService = workItemsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      var response = await _workItemsService.GetAll();

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpGet("{id:int}")]    
    public async Task<IActionResult> Get(int id) {
      var response = await _workItemsService.GetById(id);

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpGet]
    [Route("parentTicket/{id:int}")]
    public async Task<IActionResult> GetByParentTicket(int id) {
      var response = await _workItemsService.GetByTicketId(id);

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(WorkItemDTO payload) {
      if (payload == null || payload.Id > 0 || payload.TicketId <= 0) {
        return BadRequest("Invalid payload");
      }

      var response = await _workItemsService.Create(new UpsertWorkItemRequest { Payload = payload });

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpPut]
    public async Task<IActionResult> Put(WorkItemDTO payload) {
      if (payload == null || payload.Id <= 0 || payload.TicketId <= 0) {
        return BadRequest("Invalid payload");
      }

      var response = await _workItemsService.Update(new UpsertWorkItemRequest { Payload = payload });

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
      if (id <= 0) {
        return BadRequest("Invalid id");
      }

      var response = await _workItemsService.Delete(id);

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }
  }
}
