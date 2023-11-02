using System.Net.Http.Headers;
using Jira.RestClient.Requests;
using Microsoft.Extensions.Options;

namespace Jira.RestClient;

public class JiraClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    public Issues Issues => new Issues(_httpClient);
    public ServiceDeskRequests ServiceDeskRequests => new ServiceDeskRequests(_httpClient);
    public JiraClient(IOptions<JiraClientOptions> options) {

        var jiraOptions = options.Value;
        _httpClient.BaseAddress = jiraOptions.JiraUri;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", jiraOptions.BasicAuthenticationEncodedString);
			
    }
}