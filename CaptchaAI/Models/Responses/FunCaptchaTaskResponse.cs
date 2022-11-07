using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class FunCaptchaTaskResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("token")]
    public string Token { get; set; } = null!;
}