using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class HCaptchaClassificationResponse : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("objects")]
    public IList<bool> Objects { get; set; } = null!;

    [JsonProperty("box")]
    public IList<float>? Box { get; set; }

    [JsonProperty("imageSize")]
    public Tuple<int, int> ImageSize { get; set; }
}