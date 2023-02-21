using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class HCaptchaTaskResponse : ReCaptchaV2Response, ITaskResponse
{
    [JsonRequired]
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    [JsonRequired]
    [JsonProperty("captchaKey")]
    public string CaptchaKey { get; set; } = null!;
}