using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Tasks;

/// <summary>
/// This task type is used to solve AntiKasada.
/// This task type requires proxy.
/// </summary>
public class AntiKasadaTask : ITask, IProxyTask
{
    /// <summary>
    /// Address of a webpage with Kasada
    /// </summary>
    [JsonProperty("pageURL")]
    public string PageUrl { get; set; }

    /// <summary>
    /// Only cd data is returned
    /// </summary>
    /// <value></value>
    [JsonProperty("onlyCD", NullValueHandling = NullValueHandling.Ignore)]
    public string? OnlyCD { get; set; }

    /// <summary>
    /// Prepare AntiKasada task
    /// </summary>
    /// <param name="pageUrl">Address of a webpage with Kasada</param>
    /// <param name="onlyCd">Only cd data is returned</param>
    public AntiKasadaTask(string pageUrl, string? onlyCd = null)
    {
        PageUrl = pageUrl;
        OnlyCD = onlyCd;
    }
}