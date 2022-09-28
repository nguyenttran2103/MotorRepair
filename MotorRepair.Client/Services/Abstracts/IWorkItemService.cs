using MotorRepair.Models;

namespace MotorRepair.Client.Services
{
  public interface IWorkItemService
  {
    public Task<IEnumerable<WorkItemDTO>> GetAll();
    public Task<WorkItemDTO> Get(int id);
    public Task<IEnumerable<WorkItemDTO>> GetByParentTicket(int ticketId);
    public Task<WorkItemDTO> Create(WorkItemDTO payload);
    public Task<WorkItemDTO> Update(WorkItemDTO payload);
    public Task<int> Delete(int id);
  }
}
