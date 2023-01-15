using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class MtCaptchaResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("token")]
    public string Token { get; set; } = null!;
}
