using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class MtCaptchaResponse : ITaskResponse
{
    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("userAgent")]
    public string UserAgent { get; set; }
}
