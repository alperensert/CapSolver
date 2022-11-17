using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to solve HCaptcha.
/// </summary>
public class HCaptchaTask : ITask, IProxyTask, IUserAgentTask
{
    [JsonProperty("type")]
    private readonly string Type = "HCaptchaTask";

    /// <summary>
    /// Address of a webpage with hCaptcha
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    /// <summary>
    /// hCaptcha website key
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    /// <summary>
    /// Custom data that is used in some implementations of hCaptcha Enterprise. So you need to put true in the isEnterprise parameter. In most cases you see it as rqdata inside network requests. IMPORTANT: you MUST provide userAgent if you submit captcha with data parameter. The value should match the User-Agent you use when interacting with the target website.
    /// </summary>
    [JsonProperty("enterprisePayload", NullValueHandling = NullValueHandling.Ignore)]
    public object? EnterprisePayload { get; set; }

    /// <summary>
    /// Use true for enterprise version of hcaptcha
    /// </summary>
    [JsonProperty("isEnterprise", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsEnterprise { get; set; }

    /// <summary>
    /// Use true for invisible version of hcaptcha
    /// </summary>
    [JsonProperty("isInvisible", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsInvisible { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Prepare a HCaptcha task.
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with hCaptcha</param>
    /// <param name="websiteKey">hCaptcha website key</param>
    /// <param name="enterprisePayload">Custom data that is used in some implementations of hCaptcha Enterprise. So you need to put true in the isEnterprise parameter. In most cases you see it as rqdata inside network requests. IMPORTANT: you MUST provide userAgent if you submit captcha with data parameter. The value should match the User-Agent you use when interacting with the target website.</param>
    /// <param name="isEnterprise">Use true for enterprise version of hcaptcha</param>
    /// <param name="isInvisible">Use true for invisible version of hcaptcha</param>
    public HCaptchaTask(string websiteUrl,
                        string websiteKey,
                        object? enterprisePayload = null,
                        bool? isEnterprise = null,
                        bool? isInvisible = null,
                        string? userAgent = null)
    {
        WebsiteURL = websiteUrl;
        WebsiteKey = websiteKey;
        EnterprisePayload = enterprisePayload;
        IsEnterprise = isEnterprise;
        IsInvisible = isInvisible;
        UserAgent = userAgent;
    }
}