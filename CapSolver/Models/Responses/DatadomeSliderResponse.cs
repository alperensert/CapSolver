using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class DatadomeSliderResponse : ITaskResponse
{
    [JsonProperty("cookie")]
    public string Cookie { get; set; }

    [JsonRequired]
    [JsonProperty("userAgent")]
    public string UserAgent { get; set; } = null!;
}