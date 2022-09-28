using Newtonsoft.Json;

namespace MotorRepair.Client.Helpers
{
  public static class HttpClientExtension
  {
    public static async Task<T> SendRequestAsync<T>(this HttpClient httpClient, Uri url, HttpMethod method, string body = null, 
                                               List<KeyValuePair<string, string>> formBody = null, string accept = "application/json",
                                               string content = "application/json", bool useXAPIKey = false) {
      // TODO: finish in the future
      var message = "{Name: Nguyen}";
      var response = JsonConvert.DeserializeObject<T>(message);
      return await Task.FromResult(response);
    }
  }
}
