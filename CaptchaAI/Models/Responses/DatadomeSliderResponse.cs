using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class DatadomeSliderResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("cookie")]
    public string Cookie { get; set; } = null!;
}