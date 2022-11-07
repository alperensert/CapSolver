using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class ImageToTextResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("text")]
    public string Text { get; set; } = null!;
}