using System.Net.Http.Json;
using Jira.RestClient.Domain;

namespace Jira.RestClient.Requests;

public class ServiceDeskRequests
{
    private readonly HttpClient _httpClient;
    public ServiceDeskRequests(HttpClient httpClient) {
        _httpClient = httpClient;
    }
    
    public async Task<ServiceDeskRequest> GetServiceDeskRequestAsync(string issueId)
    {
        var response = await _httpClient.GetAsync($"/rest/servicedeskapi/request/{issueId}");
        response.EnsureSuccessStatusCode();
        var request = await response.Content.ReadFromJsonAsync<ServiceDeskRequest>();
        if (request == null)
        {
            throw new Exception();
        }
        return request;
			
    }
}