using AutoMapper;
using MotorRepair.ApplicationServices.Abstracts;
using MotorRepair.Models;
using MotorRepair.Models.Messaging;
using MotorRepair.Repository.Abstracts;
using MotorRepair.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.ApplicationServices
{
  public class TicketService : ITicketService
  {
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public TicketService(ITicketRepository ticketRepository, IMapper mapper) {
      _ticketRepository = ticketRepository;
      _mapper = mapper;
    }

    public async Task<UpsertTicketResponse> Create(UpsertTicketRequest request) {
      var response = new UpsertTicketResponse();

      try {
        var ticketToCreate = _mapper.Map<Ticket>(request.Payload);
        var result = await _ticketRepository.Create(ticketToCreate);

        response.Data = _mapper.Map<TicketDTO>(result);
      } catch (Exception ex) { 
        response.Exception = ex;
      }

      return response;
    }

    public async Task<DeleteTicketResponse> Delete(int id) {
      var response = new DeleteTicketResponse();

      try {
        var result = await _ticketRepository.Delete(id);
        response.Data = result;

      } catch(Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<GetAllTicketsResponse> GetAll() {
      var response = new GetAllTicketsResponse();

      try {
        var allTickets = await _ticketRepository.GetAll();

        response.Data = _mapper.Map<List<TicketDTO>>(allTickets.ToList());
      } catch (Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<GetTicketByIdResponse> GetById(int id) {
      var response = new GetTicketByIdResponse();

      try {
        var foundTicket = await _ticketRepository.GetById(id);

        response.Data = _mapper.Map<TicketDTO>(foundTicket);
      } catch(Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<UpsertTicketResponse> Update(UpsertTicketRequest request) {
      var response = new UpsertTicketResponse();

      try {
        var ticketToUpdate = _mapper.Map<Ticket>(request.Payload);
        var result = await _ticketRepository.Update(ticketToUpdate);

        response.Data= _mapper.Map<TicketDTO>(result);
      } catch(Exception ex) {
        response.Exception = ex;
      }

      return response;
    }
  }
}
