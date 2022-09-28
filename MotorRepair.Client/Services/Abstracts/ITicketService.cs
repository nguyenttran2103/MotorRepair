using MotorRepair.Models;

namespace MotorRepair.Client.Services
{
  public interface ITicketService
  {
    public Task<IEnumerable<TicketDTO>> GetAll();
    public Task<TicketDTO> Get(int id);
    public Task<TicketDTO> Create(TicketDTO payload);
    public Task<TicketDTO> Update(TicketDTO payload);
    public Task<int> Delete(int id);
  }
}
