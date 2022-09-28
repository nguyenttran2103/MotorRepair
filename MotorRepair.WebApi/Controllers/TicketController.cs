using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorRepair.ApplicationServices.Abstracts;
using MotorRepair.Models;
using MotorRepair.Models.Messaging;

namespace MotorRepair.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TicketController : ControllerBase
  {
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService) {
      _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      var response = await _ticketService.GetAll();

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id) {
      if (id <= 0) {
        return BadRequest("Invalid id");
      }

      var response = await _ticketService.GetById(id);

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      if (response.Data.Id == 0) {
        return BadRequest("Invalid id");
      }

      return Ok(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(TicketDTO payload) {
      if (payload == null || payload.Id > 0) {
        return BadRequest("Invalid payload");
      }

      var response = await _ticketService.Create(new UpsertTicketRequest { 
        Payload = payload
      });

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }

    [HttpPut]
    public async Task<IActionResult> Put(TicketDTO payload) {
      if (payload == null || payload.Id <= 0) {
        return BadRequest("Invalid payload");
      }

      var response = await _ticketService.Update(new UpsertTicketRequest {
        Payload = payload
      });

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

      var response = await _ticketService.Delete(id);

      if (response.Exception != null) {
        return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
      }

      return Ok(response.Data);
    }
  }
}
