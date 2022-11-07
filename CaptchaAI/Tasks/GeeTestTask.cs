using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Tasks;

/// <summary>
/// This task is used to solve GeeTest.
/// </summary>
public class GeeTestTask : ITask, IProxyTask, IUserAgentTask, ICookieTask
{
    [JsonProperty("type")]
    private readonly string Type = "GeetestTask";

    /// <summary>
    /// Address of a webpage with Geetest
    /// </summary>
    public string WebsiteURL { get; set; }

    /// <summary>
    /// The domain public key, rarely updated.
    /// </summary>
    [JsonRequired]
    [JsonProperty("gt")]
    public string Gt { get; set; }

    /// <summary>
    /// Changing token key. Make sure you grab a fresh one for each captcha; otherwise, you'll be charged for an error task.
    /// </summary>
    [JsonRequired]
    [JsonProperty("challenge")]
    public string Challenge { get; set; }

    /// <summary>
    /// Optional API subdomain. May be required for some implementations.
    /// </summary>
    [JsonProperty("geetestApiServerSubdomain", NullValueHandling = NullValueHandling.Ignore)]
    public string? ApiServerSubdomain { get; set; }

    /// <summary>
    /// Required for some implementations. Send the JSON encoded into a string. The value can be traced in browser developer tools. Put a breakpoint before calling the "initGeetest" function.
    /// </summary>
    [JsonProperty("geetestGetLib", NullValueHandling = NullValueHandling.Ignore)]
    public string? GeeTestGetLib { get; set; }

    /// <summary>
    /// Version number. Default version is 3.
    /// </summary>
    [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
    public string? Version { get; set; }

    /// <summary>
    /// Additional initialization parameters for version 4
    /// </summary>
    [JsonProperty("initParameters", NullValueHandling = NullValueHandling.Ignore)]
    public string? InitParameters { get; set; }
    
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
    /// Preapre a GeeTest task
    /// </summary>
    /// <param name="websiteUrl">Address of a webpage with Geetest</param>
    /// <param name="gt">The domain public key, rarely updated.</param>
    /// <param name="challenge">Changing token key. Make sure you grab a fresh one for each captcha; otherwise, you'll be charged for an error task.</param>
    /// <param name="apiServerSubdomain">Optional API subdomain. May be required for some implementations.</param>
    /// <param name="getLib">Required for some implementations. Send the JSON encoded into a string. The value can be traced in browser developer tools. Put a breakpoint before calling the "initGeetest" function.</param>
    /// <param name="version">Version number. Default version is 3.</param>
    /// <param name="initParameters">Additional initialization parameters for version 4</param>
    /// <param name="cookies">Additional cookies which we must use during interaction with target page or Google.</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation.</param>
    public GeeTestTask(string websiteUrl,
                       string gt,
                       string challenge,
                       string? apiServerSubdomain = null,
                       string? getLib = null,
                       string? version = null,
                       string? initParameters = null,
                       string? cookies = null,
                       string? userAgent = null)
    {
        WebsiteURL = websiteUrl;
        Gt = gt;
        Challenge = challenge;
        ApiServerSubdomain = apiServerSubdomain;
        GeeTestGetLib = getLib;
        Version = version;
        InitParameters = initParameters;
        UserAgent = userAgent;
        Cookies = cookies;
    }
}