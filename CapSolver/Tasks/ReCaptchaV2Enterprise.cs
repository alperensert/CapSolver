using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to solve the ReCaptchaV2 Enterprise version.
/// </summary>
public class ReCaptchaV2Enterprise : ITask, IProxyTask, IUserAgentTask, ICookieTask
{
    /// <summary>
    /// Task's type.
    /// </summary>
    [JsonProperty("type")]
    private readonly string Type = "ReCaptchaV2EnterpriseTask";

    /// <summary>
    /// Address of a webpage with Google ReCaptcha
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteURL")]
    public string WebsiteUrl { get; set; }

    /// <summary>
    /// ReCaptchaV2 website key.
    /// </summary>
    [JsonRequired]
    [JsonProperty("websiteKey")]
    public string WebsiteKey { get; set; }

    /// <summary>
    /// Some implementations of the reCAPTCHA Enterprise widget
    /// may contain additional parameters that are passed to the
    /// “grecaptcha.enterprise.render” method along with the sitekey.
    /// </summary>
    [JsonProperty("enterprisePayload", NullValueHandling = NullValueHandling.Ignore)]
    public object? EnterprisePayload { get; set; }

    /// <summary>
    /// Domain address from which to load reCAPTCHA Enterprise. 
    /// </summary>
    [JsonProperty("apiDomain", NullValueHandling = NullValueHandling.Ignore)]
    public string? ApiDomain { get; set; }

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
    /// Prepare a ReCaptchaV2 Enterprise task.
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Google ReCaptcha</param>
    /// <param name="websiteKey">ReCaptchaV2 website key.</param>
    /// <param name="enterprisePayload">Some implementations of the reCAPTCHA Enterprise widget
    /// may contain additional parameters that are passed to the
    /// “grecaptcha.enterprise.render” method along with the sitekey.</param>
    /// <param name="apiDomain">Domain address from which to load reCAPTCHA Enterprise. </param>
    /// <param name="cookies">Additional cookies which we must use during interaction with target page or Google.</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    public ReCaptchaV2Enterprise(string websiteUrl,
                                 string websiteKey,
                                 object? enterprisePayload = null,
                                 string? apiDomain = null,
                                 string? userAgent = null,
                                 string? cookies= null)
    {
        WebsiteUrl = websiteUrl;
        WebsiteKey = websiteKey;
        EnterprisePayload = enterprisePayload;
        ApiDomain = apiDomain;
        UserAgent = userAgent;
        Cookies = cookies;
    }
}