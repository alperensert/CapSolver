using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

public class MtCaptchaTask : ITask, IProxyTask, IUserAgentTask
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
    /// if the url contains t=bv that means that your ip must be banned, t should be t=fe
    /// </summary>
    [JsonRequired]
    [JsonProperty("captchaUrl")]
    public string CaptchaURL { get; set; }

    /// <summary>
    /// Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".
    /// </summary>
    [JsonRequired]
    [JsonProperty("userAgent")]
    public string UserAgent { get; set; }

    /// <summary>
    /// </summary>
    /// <param name="websiteUrl">Web address of the website using hcaptcha, generally it's fixed value.</param>
    /// <param name="captchaUrl">if the url contains t=bv that means that your ip must be banned, t should be t=fe</param>
    /// <param name="userAgent">Browser's User-Agent which is used in emulation. It is required that you use a signature of a modern browser, otherwise Google will ask you to "update your browser".</param>
    public MtCaptchaTask(string websiteUrl,
                         string captchaUrl,
                         string userAgent)
    {
        CaptchaURL = captchaUrl;
        WebsiteURL = websiteUrl;
        UserAgent = userAgent;
    }
}
