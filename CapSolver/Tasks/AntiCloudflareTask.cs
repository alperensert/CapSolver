using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

public class AntiCloudflareTask : ITask, IProxyTask
{
    [JsonProperty("type")]
    private readonly string Type = "AntiCloudflareTask";

    /// <summary>
    /// The address of the target page.
    /// </summary>
    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    /// <summary>
    /// Turnstile siteKey
    /// </summary>
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    /// <summary>
    /// Turnstile extra data
    /// </summary>
    [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string>? MetaData { get; set; }

    /// <summary>
    /// Prepare an AntiCloudflare task.
    /// </summary>
    /// <param name="websiteUrl">The address of the target page.</param>
    /// <param name="websiteKey">Turnstile siteKey</param>
    /// <param name="metaData">Turnstile extra data</param>
    public AntiCloudflareTask(string websiteUrl,
                              string websiteKey,
                              Dictionary<string, string>? metaData = null)
    {
        WebsiteKey = websiteKey;
        WebsiteURL = websiteUrl;
        MetaData = metaData;
    }
}
