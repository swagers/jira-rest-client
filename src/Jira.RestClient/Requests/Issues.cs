using System.Net.Http.Json;
using Jira.RestClient.Domain;

namespace Jira.RestClient.Requests;

public class Issues
{
    private readonly HttpClient _httpClient;
    public Issues(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<Issue> GetIssueAsync(string issueId)
    {
        var response = await _httpClient.GetAsync($"/rest/agile/1.0/issue/{issueId}");
        response.EnsureSuccessStatusCode();
        var issue = await response.Content.ReadFromJsonAsync<Issue>();
        return issue;

    }

    public async Task<Issue> CreateIssueAsync(Issue issue)
    {
        var response = await _httpClient.PostAsJsonAsync("/res", issue);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Issue>();	

    }
		
}