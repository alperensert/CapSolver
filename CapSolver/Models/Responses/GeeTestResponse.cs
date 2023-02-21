using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class GeeTestResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("challenge")]
    public string Challenge { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("validate")]
    public string Validate { get; set; } = null!;
}