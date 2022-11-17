using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

/// <summary>
/// This task type is used to solve HCaptchaClassification
/// </summary>
public class HCaptchaClassificationTask : ITask
{
    [JsonProperty("type")]
    private readonly string Type = "HCaptchaClassification";

    /// <summary>
    /// Base64-encoded images, do not include "data:image/***;base64,"
    /// </summary>
    [JsonRequired]
    [JsonProperty("queries")]
    public IList<string> Queries { get; set; }

    /// <summary>
    /// Question ID. Support English and Chinese, other languages please convert yourself
    /// </summary>
    [JsonProperty("question", NullValueHandling = NullValueHandling.Ignore)]
    public string? Question { get; set; }

    /// <summary>
    /// The default result is false. If you need to return coordinates such as [0, 3, 4, 6, 7], put as true.
    /// </summary>
    [JsonProperty("coordinate", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Coordinate { get; set; }

    /// <summary>
    /// Prepare a HCaptchaClassification task.
    /// </summary>
    /// <param name="queries">Base64-encoded images, do not include "data:image/***;base64,"Base64-encoded images, do not include "data:image/***;base64,"</param>
    /// <param name="question">Question ID. Support English and Chinese, other languages please convert yourself</param>
    /// <param name="coordinate">The default result is false. If you need to return coordinates such as [0, 3, 4, 6, 7], put as true.</param>
    public HCaptchaClassificationTask(IList<string> queries,
                                      string? question = null,
                                      bool? coordinate = null)
    {
        Queries = queries;
        Question = question;
        Coordinate = coordinate;
    }
}