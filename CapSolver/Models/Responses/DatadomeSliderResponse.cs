using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class DatadomeSliderResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("cookie")]
    public string Cookie { get; set; } = null!;
}