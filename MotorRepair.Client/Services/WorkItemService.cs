using MotorRepair.Models;
using Newtonsoft.Json;
using System.Text;

namespace MotorRepair.Client.Services
{
  public class WorkItemService : IWorkItemService
  {
    private readonly HttpClient _httpClient;

    public WorkItemService(HttpClient httpClient) {
      _httpClient = httpClient;
    }

    public async Task<WorkItemDTO> Create(WorkItemDTO payload) {
      var body = JsonConvert.SerializeObject(payload);
      var bodyContent = new StringContent(body, Encoding.UTF8, "application/json");
      var response = await _httpClient.PostAsync(Constants.WebServiceRoutes.CreateWorkItem, bodyContent);
      var result = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<WorkItemDTO>(result);
      }
      else {
        throw new Exception(result);
      }
    }

    public async Task<int> Delete(int id) {
      var response = await _httpClient.DeleteAsync(string.Format(Constants.WebServiceRoutes.DeleteWorkItem, id));
      var result = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return int.Parse(result);
      }
      else {
        throw new Exception(result);
      }
    }

    public async Task<WorkItemDTO> Get(int id) {
      var response = await _httpClient.GetAsync(string.Format(Constants.WebServiceRoutes.GetWorkItemById, id));
      var content = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<WorkItemDTO>(content);
      }
      else {
        throw new Exception(content);
      }
    }

    public async Task<IEnumerable<WorkItemDTO>> GetAll() {
      var response = await _httpClient.GetAsync(Constants.WebServiceRoutes.GetAllWorkItems);
      var content = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<IEnumerable<WorkItemDTO>>(content);
      }
      else {
        throw new Exception(content);
      }
    }

    public async Task<IEnumerable<WorkItemDTO>> GetByParentTicket(int ticketId) {
      var response = await _httpClient.GetAsync(string.Format(Constants.WebServiceRoutes.GetWorkItemByParentTicket, ticketId));
      var content = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<IEnumerable<WorkItemDTO>>(content);
      } else {
        throw new Exception(content);
      }
    }

    public async Task<WorkItemDTO> Update(WorkItemDTO payload) {
      var body = JsonConvert.SerializeObject(payload);
      var bodyContent = new StringContent(body, Encoding.UTF8, "application/json");
      var response = await _httpClient.PutAsync(Constants.WebServiceRoutes.UpdateWorkItem, bodyContent);
      var result = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<WorkItemDTO>(result);
      }
      else {
        throw new Exception(result);
      }
    }
  }
}
