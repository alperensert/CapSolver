using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

public class BinanceCaptchaTask : ITask, IProxyTask
{
    [JsonProperty("type")]
    private readonly string Type = "BinanceCaptchaTask";

    /// <summary>
    /// Address of a webpage with bncaptcha
    /// </summary>
    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    /// <summary>
    /// bizId always be login
    /// </summary>
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    /// <summary>
    /// validateId bncaptcha validateId field
    /// </summary>
    [JsonProperty("validateId")]
    public string ValidateId { get; set; }

    /// <summary>
    /// Prepare a BinanceCaptcha task.
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with bncaptcha</param>
    /// <param name="websiteKey">bizId always be login</param>
    /// <param name="validateId">validateId bncaptcha validateId field</param>
    public BinanceCaptchaTask(string websiteUrl,
                              string websiteKey,
                              string validateId)
    {
        WebsiteKey = websiteKey;
        WebsiteURL = websiteUrl;
        ValidateId = validateId;
    }
}
