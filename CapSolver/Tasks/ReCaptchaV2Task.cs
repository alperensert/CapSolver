using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to solve the reCaptchaV2 version
/// </summary>
public class ReCaptchaV2Task : ITask, IUserAgentTask, ICookieTask, IProxyTask
{
    [JsonProperty("type")]
    private readonly string Type = "ReCaptchaV2Task";

    /// <summary>
    /// Address of a webpage with Google ReCaptcha
    /// </summary>
    [JsonProperty("websiteURL")]
    private string WebsiteUrl { get; set; }

    /// <summary>
    /// Recaptcha website key. <div class="g-recaptcha" data-sitekey="THAT_ONE"></div>
    /// </summary>
    [JsonProperty("websiteKey")]
    private string WebsiteKey { get; set; }

    /// <summary>
    /// Specify whether or not Recaptcha is invisible.
    /// </summary>
    [JsonProperty("isInvisible", NullValueHandling = NullValueHandling.Ignore)]
    private bool? IsInvisible { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Additional cookies which we must use during interaction with target page or Google.
    /// </summary>
    [JsonProperty("cookies", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cookies { get; set; }

    /// <summary>
    /// Prepare a ReCaptchaV2 task
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Google ReCaptcha</param>
    /// <param name="websiteKey">Recaptcha website key. <div class="g-recaptcha" data-sitekey="THAT_ONE"></div></param>
    /// <param name="isInvisible">Specify whether or not Recaptcha is invisible.</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    /// <param name="cookies">Additional cookies which we must use during interaction with target page or Google.</param>
    public ReCaptchaV2Task(string websiteUrl,
                           string websiteKey,
                           bool? isInvisible = null,
                           string? userAgent = null,
                           string? cookies = null)
    {
        WebsiteUrl = websiteUrl;
        WebsiteKey = websiteKey;
        IsInvisible = isInvisible;
        UserAgent = userAgent;
        Cookies = cookies;
    }
}