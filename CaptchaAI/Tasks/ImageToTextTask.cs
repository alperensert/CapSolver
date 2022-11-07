using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Tasks;

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
    /// Prepare an image to text task.
    /// </summary>
    /// <param name="body">Base64 encoded content of the image (without line breaks)</param>
    public ImageToTextTask(string body)
    {
        Body = body;
    }
}