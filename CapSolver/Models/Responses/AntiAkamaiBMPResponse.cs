using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class AntiAkamaiBMPResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("deviceId")]
    public string DeviceId { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("sensors")]
    public IList<string> Sensors { get; set; } = null!;

    [JsonRequired]
    [JsonProperty("version")]
    public string Version { get; set; } = null!;
}