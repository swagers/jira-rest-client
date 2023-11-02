using System.Net;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace Jira.RestClient.Tests;

public class IssueTests
{
    private readonly IOptions<JiraClientOptions> _options;
    private readonly JiraClient _jiraClient;
    public IssueTests()
    {
        var clientoptions = new JiraClientOptions();
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .Build();
        configuration.GetSection(nameof(JiraClientOptions)).Bind(clientoptions);
			
        //_apiKey = configuration.GetValue<string>("ApiKey");
        _options = Options.Create(clientoptions);
        _jiraClient = new JiraClient(_options);
    }
    
    
    [Fact]
    public async Task TestGettingIssue()
    {
        var issue = await _jiraClient.Issues.GetIssueAsync("RLR275B-275");
        Assert.Equal("13662", issue.Id);
    }
    
    [Fact]
    public async Task TestGettingIssueWithBadIssueId()
    {
        var exception = await Assert.ThrowsAsync<HttpRequestException>(() =>  _jiraClient.Issues.GetIssueAsync("RLR275B-27235"));
        Assert.True(exception.StatusCode == HttpStatusCode.NotFound);
        
        
    }
}