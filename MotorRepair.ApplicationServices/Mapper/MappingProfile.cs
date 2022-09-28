using AutoMapper;
using MotorRepair.Models;
using MotorRepair.Repository.Entities;

namespace MotorRepair.ApplicationServices.Mapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile() {
      CreateMap<Ticket, TicketDTO>().ReverseMap();
      CreateMap<WorkItem, WorkItemDTO>().ReverseMap();
    }
  }
}
