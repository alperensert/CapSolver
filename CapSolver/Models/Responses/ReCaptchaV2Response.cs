using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class ReCaptchaV2Response : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("gRecaptchaResponse")]
    public string GReCaptchaResponse { get; set; } = null!;

    [JsonProperty("userAgent")]
    public string UserAgent { get; set; } = null!;

    [JsonProperty("expireTime")]
    public long ExpireTime { get; set; }
}