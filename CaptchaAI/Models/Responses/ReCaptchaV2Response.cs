using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class ReCaptchaV2Response : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("gRecaptchaResponse")]
    public string GReCaptchaResponse { get; set; } = null!;
}