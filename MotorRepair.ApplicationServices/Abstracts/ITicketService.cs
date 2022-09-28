using MotorRepair.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.ApplicationServices.Abstracts
{
  public interface ITicketService
  {
    Task<UpsertTicketResponse> Create(UpsertTicketRequest request);
    Task<UpsertTicketResponse> Update(UpsertTicketRequest request);
    Task<DeleteTicketResponse> Delete(int id);
    Task<GetAllTicketsResponse> GetAll();
    Task<GetTicketByIdResponse> GetById(int id);
  }
}
