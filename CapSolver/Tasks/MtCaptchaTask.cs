using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

public class MtCaptchaTask : ITask, IProxyTask
{
    [JsonProperty("type")]
    private readonly string Type = "MtCaptchaTask";

    /// <summary>
    /// Web address of the website using hcaptcha, generally it's fixed value. (Ex: https://google.com)
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    /// <summary>
    /// The domain public key, rarely updated. (Ex: sk=MTPublic-xxx public key)
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    public MtCaptchaTask(string websiteUrl,
                         string websiteKey)
    {
        WebsiteKey = websiteKey;
        WebsiteURL = websiteUrl;
    }
}
