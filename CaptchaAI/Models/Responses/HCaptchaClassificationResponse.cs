using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class HCaptchaClassificationResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("objects")]
    public IList<bool> Objects { get; set; } = null!;
}