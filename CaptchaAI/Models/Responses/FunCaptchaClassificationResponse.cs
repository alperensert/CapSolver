using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class FunCaptchaClassificationResponse : ITaskResponse
{
    [JsonProperty("objects", NullValueHandling = NullValueHandling.Include)]
    public IList<int>? Objects { get; set; }

    [JsonProperty("labels", NullValueHandling = NullValueHandling.Include)]
    public IList<string>? Labels { get; set; }

    [JsonProperty("hasObject", NullValueHandling = NullValueHandling.Include)]
    public bool? HasObject { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Include)]
    public string? Type { get; set; }
}