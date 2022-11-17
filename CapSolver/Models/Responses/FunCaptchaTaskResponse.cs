using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class FunCaptchaTaskResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("token")]
    public string Token { get; set; } = null!;
}