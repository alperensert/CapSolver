using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to solve FunCaptchaClassification.
/// </summary>
public class FunCaptchaClassification : ITask
{
    [JsonProperty("type")]
    private readonly string Type = "FunCaptchaClassification";

    /// <summary>
    /// Base64 encoded image, can be a screenshot (pass only the hexagonal image, do not pass the rest of the content)
    /// </summary>
    [JsonRequired]
    [JsonProperty("image")]
    public string Image { get; set; }

    /// <summary>
    /// Question name. Pass the full name, such as: Pick the lion
    /// Only support English requires accurate case, other languages please convert to English yourself
    /// The server will automatically determine different image types according to the question, so please make sure the question is correct.
    /// Please see the list at the end of the document for the full list of image types and corresponding English questions
    /// <br/>
    /// See the supported question list: <seealso href="https://docs.capsolver.com/guide/recognition/FunCaptchaClassification.html#create-task">click here</seealso>
    /// </summary>
    [JsonRequired]
    [JsonProperty("question")]
    public string Question { get; set; }

    /// <summary>
    /// Prepare a FunCaptchaClassification task.
    /// <br/>
    /// See supported types of FunCaptcha: <seealso href="https://docs.capsolver.com/guide/recognition/FunCaptchaClassification.html#supported-types">click here</seealso>
    /// </summary>
    /// <param name="image">Base64 encoded image, can be a screenshot (pass only the hexagonal image, do not pass the rest of the content)</param>
    /// <param name="question">Question name. Pass the full name, such as: Pick the lion. Only support English requires accurate case, other languages please convert to English yourself.<br/>See the supported question list: <seealso href="https://docs.capsolver.com/guide/recognition/FunCaptchaClassification.html#create-task">click here</seealso></param>
    public FunCaptchaClassification(string image, string question)
    {
        Image = image;
        Question = question;
    }
}