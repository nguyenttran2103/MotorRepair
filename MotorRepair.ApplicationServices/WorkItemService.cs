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
  public class WorkItemService : IWorkItemService
  {
    private readonly IWorkItemRepository _workItemRepository;
    private readonly IMapper _mapper;

    public WorkItemService(IWorkItemRepository workItemRepository, IMapper mapper) {
      _workItemRepository = workItemRepository;
      _mapper = mapper;
    }

    public async Task<UpsertWorkItemResponse> Create(UpsertWorkItemRequest request) {
      var response = new UpsertWorkItemResponse();

      try {
        var workItemToCreate = _mapper.Map<WorkItem>(request.Payload);
        var result = await _workItemRepository.Create(workItemToCreate);

        response.Data = _mapper.Map<WorkItemDTO>(result);
      } catch (Exception ex) {
        response.Exception = ex; 
      }

      return response;
    }

    public async Task<DeleteWorkItemResponse> Delete(int id) {
      var response = new DeleteWorkItemResponse();

      try {
        var result = await _workItemRepository.Delete(id);
        response.Data = result;
      } catch (Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<GetAllWorkItemsResponse> GetAll() {
      var response = new GetAllWorkItemsResponse();

      try {
        var result = await _workItemRepository.GetAll();
        response.Data = _mapper.Map<List<WorkItemDTO>>(result);
      } catch (Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<GetWorkItemByIdResponse> GetById(int id) {
      var response = new GetWorkItemByIdResponse();

      try {
        var foundWokItem = await _workItemRepository.GetById(id);
        response.Data = _mapper.Map<WorkItemDTO>(foundWokItem);
      } catch (Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<GetWorkItemsByTicketIdResponse> GetByTicketId(int ticketId) {
      var response = new GetWorkItemsByTicketIdResponse();

      try {
        var foundWorkItems = await _workItemRepository.GetByTicketId(ticketId);
        response.Data = _mapper.Map<List<WorkItemDTO>>(foundWorkItems);
      } catch (Exception ex) {
        response.Exception = ex;
      }

      return response;
    }

    public async Task<UpsertWorkItemResponse> Update(UpsertWorkItemRequest request) {
      var response = new UpsertWorkItemResponse();

      try {
        var itemToUpdate = _mapper.Map<WorkItem>(request.Payload);
        var result = await _workItemRepository.Update(itemToUpdate);

        response.Data = _mapper.Map<WorkItemDTO>(result);
      } catch (Exception ex) {
        response.Exception = ex;
      }

      return response;
    }
  }
}
