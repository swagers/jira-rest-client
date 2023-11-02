namespace Jira.RestClient;

public class JiraClientOptions
{
    public Uri JiraUri { get; set; }
    public string ApiKey { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public string BasicAuthenticationEncodedString { get
        {
            var authData = System.Text.Encoding.UTF8.GetBytes($"{UserName}:{ApiKey}");
            var basicAuthentication = Convert.ToBase64String(authData);
            return basicAuthentication;
        } 
    }
}