using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class HCaptchaClassificationResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("objects")]
    public IList<bool> Objects { get; set; } = null!;
}