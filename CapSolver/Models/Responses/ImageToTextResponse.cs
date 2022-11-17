using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class ImageToTextResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("text")]
    public string Text { get; set; } = null!;
}