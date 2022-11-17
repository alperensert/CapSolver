using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class GetBalance : ErrorResponse
{
    [JsonRequired]
    [JsonProperty("balance", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public float Balance { get; set; }

    [JsonRequired]
    [JsonProperty("packages", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<string?> Packages { get; set; } = null!;
}