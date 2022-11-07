using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class AntiKasadaResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("x-kpsdk-ct")]
    public string KPsdkCT { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("x-kpsdk-cd")]
    public string KPsdkCD { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("user-agent")]
    public string UserAgent { get; set; } = null!;
}