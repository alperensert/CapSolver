using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task is used to solve GeeTest.
/// </summary>
public class GeeTestTask : ITask, IProxyTask, IUserAgentTask, ICookieTask
{
    [JsonProperty("type")]
    private readonly string Type = "GeeTestTask";

    /// <summary>
    /// Address of a webpage with Geetest
    /// </summary>
    public string WebsiteURL { get; set; }

    /// <summary>
    /// The domain public key, rarely updated.
    /// </summary>
    [JsonProperty("gt", NullValueHandling = NullValueHandling.Ignore)]
    public string? Gt { get; set; }

    /// <summary>
    /// Changing token key. Make sure you grab a fresh one for each captcha; otherwise, you'll be charged for an error task.
    /// </summary>
    [JsonProperty("challenge", NullValueHandling = NullValueHandling.Ignore)]
    public string? Challenge { get; set; }

    [JsonProperty("captchaId")]
    public string? CaptchaId { get; set; }

    /// <summary>
    /// Optional API subdomain. May be required for some implementations.
    /// </summary>
    [JsonProperty("geetestApiServerSubdomain", NullValueHandling = NullValueHandling.Ignore)]
    public string? ApiServerSubdomain { get; set; }
    
    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Preapre a GeeTest task
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Geetest</param>
    /// <param name="gt">The domain public key, rarely updated.</param>
    /// <param name="challenge">Changing token key. Make sure you grab a fresh one for each captcha; otherwise, you'll be charged for an error task.</param>
    /// <param name="apiServerSubdomain">Optional API subdomain. May be required for some implementations.</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    public GeeTestTask(string websiteUrl,
                       string? gt = null,
                       string? challenge = null,
                       string? apiServerSubdomain = null,
                       string? userAgent = null,
                       string? captchaId = null)
    {
        WebsiteURL = websiteUrl;
        Gt = gt;
        Challenge = challenge;
        ApiServerSubdomain = apiServerSubdomain;
        UserAgent = userAgent;
        CaptchaId = captchaId;
        if (gt != null && challenge != null)
        {
            CaptchaId = null;
        }
    }
}