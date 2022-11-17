using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to solve DatadomeSlider.
/// This task type requires proxy.
/// </summary>
public class DatadomeSliderTask : ITask, IProxyTask
{
    [JsonProperty("type")]
    private readonly string Type = "DatadomeSliderTask";

    /// <summary>
    /// Address of the webpage
    /// </summary>
    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    /// <summary>
    /// Captcha Url where is the captcha
    /// </summary>
    [JsonProperty("captchaUrl")]
    public string CaptchaURL { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser"
    /// </summary>
    /// <value></value>
    [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Prepare a DatadomeSlider task.
    /// </summary>
    /// <param name="websiteUrl">Address of the webpage</param>
    /// <param name="captchaUrl">Captcha Url where is the captcha</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser"</param>
    public DatadomeSliderTask(string websiteUrl,
                              string captchaUrl,
                              string? userAgent = null)
    {
        WebsiteURL = websiteUrl;
        CaptchaURL = captchaUrl;
        UserAgent = userAgent;
    }
}