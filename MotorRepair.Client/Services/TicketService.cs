using MotorRepair.Models;
using Newtonsoft.Json;
using System.Text;

namespace MotorRepair.Client.Services
{
  public class TicketService : ITicketService
  {
    private readonly HttpClient _httpClient;

    public TicketService(HttpClient httpClient) {
      _httpClient = httpClient;
    }

    public async Task<TicketDTO> Create(TicketDTO payload) {
      var body = JsonConvert.SerializeObject(payload);
      var bodyContent = new StringContent(body, Encoding.UTF8, "application/json");
      var response = await _httpClient.PostAsync(Constants.WebServiceRoutes.CreateTicket, bodyContent);
      var result = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<TicketDTO>(result);
      } else {
        throw new Exception(result);
      }
    }

    public async Task<int> Delete(int id) {
      var response = await _httpClient.DeleteAsync(string.Format(Constants.WebServiceRoutes.DeleteTicket, id));
      var result = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return int.Parse(result);
      } else {
        throw new Exception(result);
      }
    }

    public async Task<TicketDTO> Get(int id) {
      var response = await _httpClient.GetAsync(string.Format(Constants.WebServiceRoutes.GetTicketById, id));
      var content = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<TicketDTO>(content);
      } else {
        throw new Exception(content);
      }
    }

    public async Task<IEnumerable<TicketDTO>> GetAll() {
      var response = await _httpClient.GetAsync(Constants.WebServiceRoutes.GetAllTickets);
      var content = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {        
        return JsonConvert.DeserializeObject<IEnumerable<TicketDTO>>(content);
      } else {
        throw new Exception(content);
      }
    }

    public async Task<TicketDTO> Update(TicketDTO payload) {
      var body = JsonConvert.SerializeObject(payload);
      var bodyContent = new StringContent(body, Encoding.UTF8, "application/json");
      var response = await _httpClient.PutAsync(Constants.WebServiceRoutes.UpdateTicket, bodyContent);
      var result = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode) {
        return JsonConvert.DeserializeObject<TicketDTO>(result);
      } else {
        throw new Exception(result);
      }
    }
  }
}
