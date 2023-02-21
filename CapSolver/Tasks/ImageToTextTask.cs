using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to recognize image captchas.
/// </summary>
public class ImageToTextTask : ITask
{
    /// <summary>
    /// Task's type.
    /// </summary>
    [JsonProperty("type")]
    private readonly string Type = "ImageToTextTask";

    /// <summary>
    /// Base64 encoded content of the image (without line breaks)
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>
    /// Specifies the module. Currently, the supported modules are common and queueit.
    /// </summary>
    [JsonProperty("module")]
    public string? Module { get; set; }

    /// <summary>
    /// Identify the matching degree. If the recognition rate is not within the range, no deduction
    /// </summary>
    /// <value>0.8 ~ 1</value>
    [JsonProperty("score")]
    public float? Score { get; set; }

    /// <summary>
    /// Case sensitive or not
    /// </summary>
    [JsonProperty("case")]
    public bool? Case { get; set; }

    /// <summary>
    /// Prepare an image to text task.
    /// </summary>
    /// <param name="body">Base64 encoded content of the image (without line breaks)</param>
    public ImageToTextTask(string body, string? module = null, float? score = null, bool? caseSensitive = null)
    {
        Body = body;
        Module = module;
        Score = score;
        Case = caseSensitive;
    }
}