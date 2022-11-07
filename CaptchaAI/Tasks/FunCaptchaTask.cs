using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Tasks;

/// <summary>
/// This task type is used to solve FunCaptcha
/// </summary>
public class FunCaptchaTask : ITask, IProxyTask, IUserAgentTask
{
    [JsonProperty("type")]
    private readonly string Type = "FunCaptchaTask";

    /// <summary>
    /// Address of a webpage with Funcaptcha
    /// </summary>
    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    /// <summary>
    /// Funcaptcha website key.
    /// </summary>
    [JsonProperty("websitePublicKey")]
    public string WebsitePublicKey { get; set; }

    /// <summary>
    /// A special subdomain of funcaptcha.com, from which the JS captcha widget should be loaded. Most FunCaptcha installations work from shared domains.
    /// </summary>
    [JsonProperty("funcaptchaApiJSSubdomain")]
    public string ApiJsSubdomain { get; set; }

    /// <summary>
    /// Additional parameter that may be required by FunCaptcha implementation. Use this property to send "blob" value as a stringified array. See example how it may look like. 
    /// </summary>
    [JsonProperty("data")]
    public string? Data { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser"
    /// </summary>
    /// <value></value>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Prepare a FunCaptcha task
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Funcaptcha</param>
    /// <param name="websitePublicKey">Funcaptcha website key.</param>
    /// <param name="apiJsSubdomain">A special subdomain of funcaptcha.com, from which the JS captcha widget should be loaded. Most FunCaptcha installations work from shared domains.</param>
    /// <param name="data">Additional parameter that may be required by FunCaptcha implementation. Use this property to send "blob" value as a stringified array. See example how it may look like. </param>
    public FunCaptchaTask(string websiteUrl,
                          string websitePublicKey,
                          string apiJsSubdomain,
                          string? data = null,
                          string? userAgent = null)
    {
        WebsiteURL = websiteUrl;
        WebsitePublicKey = websitePublicKey;
        ApiJsSubdomain = apiJsSubdomain;
        Data = data;
        UserAgent = userAgent;
    }
}