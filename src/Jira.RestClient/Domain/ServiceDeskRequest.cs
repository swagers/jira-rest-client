namespace Jira.RestClient.Domain;

public class ServiceDeskRequest
{
    // public string serviceDeskId { get; set; }
    // public string requestTypeId { get; set; }
    // public RequestFieldValues requestFieldValues { get; set; }
    // public string[] requestParticipants { get; set; }
    public string issueKey { get; set; }
}

public class RequestFieldValues
{
    public string summary { get; set; }
    public string description { get; set; }
}
