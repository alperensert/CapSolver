using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class BinanceCaptchaResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("token")]
    public string Token { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("userAgent")]
    public string UserAgent { get; set; } = null!;
}
