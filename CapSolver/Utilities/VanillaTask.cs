using Newtonsoft.Json;

namespace CapSolver.Utilities;

public class VanillaTask
{
    /// <summary>
    /// The client key (api key) which belongs to your account
    /// </summary>
    [JsonRequired]
    [JsonProperty("clientKey", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientKey { get; set; } = null!;

    [JsonProperty("task", NullValueHandling = NullValueHandling.Ignore)]
    public ITask? Task { get; private set; }

    [JsonProperty("taskId", NullValueHandling = NullValueHandling.Ignore)]
    public string? TaskId { get; set; }

    [JsonProperty("appId", NullValueHandling = NullValueHandling.Ignore)]
    private string? AppId { get; set; }

    public VanillaTask(string clientKey, ITask? task = null)
    {
        Task = task;
        ClientKey = clientKey;
    }

    public void UseAppId() => AppId = "E2C4EB50-89C3-4F7E-AE67-F92D2F36C4FF";
}