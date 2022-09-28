using MotorRepair.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorRepair.ApplicationServices.Abstracts
{
  public interface IWorkItemService
  {
    Task<UpsertWorkItemResponse> Create(UpsertWorkItemRequest request);
    Task<UpsertWorkItemResponse> Update(UpsertWorkItemRequest request);
    Task<DeleteWorkItemResponse> Delete(int id);
    Task<GetAllWorkItemsResponse> GetAll();
    Task<GetWorkItemByIdResponse> GetById(int id);
    Task<GetWorkItemsByTicketIdResponse> GetByTicketId(int ticketId);
  }
}
