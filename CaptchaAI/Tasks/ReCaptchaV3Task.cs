using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Tasks;

/// <summary>
/// This task type is used to solve ReCaptchaV3.
/// </summary>
public class ReCaptchaV3Task : ITask, IProxyTask, IUserAgentTask, ICookieTask
{
    [JsonProperty("type")]
    private readonly string Type = "ReCaptchaV3Task";

    /// <summary>
    /// Address of a webpage with Google ReCaptcha 
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// ReCaptchaV3 website key.
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }
    
    /// <summary>
    /// Widget action value. Website owner defines what user is doing on the page through this parameter. Default value: verify
    /// </summary>
    [JsonRequired]
    [JsonProperty("pageAction")]
    public string PageAction { get; set; } = "verify";

    /// <summary>
    /// Value from 0.1 to 0.9
    /// </summary>
    [JsonProperty("minScore", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinimumScore { get; set; }

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
    /// Prepare a ReCaptchaV3 task.
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Google ReCaptcha </param>
    /// <param name="websiteKey">ReCaptchaV3 website key.</param>
    /// <param name="pageAction">Widget action value. Website owner defines what user is doing on the page through this parameter. Default value: verify</param>
    /// <param name="minimumScore">Value from 0.1 to 0.9</param>
    /// <param name="cookies">Additional cookies which we must use during interaction with target page or Google.</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    public ReCaptchaV3Task(string websiteUrl,
                           string websiteKey,
                           string pageAction,
                           double? minimumScore = null,
                           string? cookies = null,
                           string? userAgent = null)
    {
        WebsiteKey = websiteKey;
        WebsiteUrl = websiteUrl;
        PageAction = pageAction;
        MinimumScore = minimumScore;
        UserAgent = userAgent;
        Cookies = cookies;
    }
}