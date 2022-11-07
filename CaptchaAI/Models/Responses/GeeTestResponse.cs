using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class GeeTestResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("challenge")]
    public string Challenge { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("validate")]
    public string Validate { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("seccode")]
    public string SecCode { get; set; } = null!;
}