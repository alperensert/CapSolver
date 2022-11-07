using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Models.Responses;

public class TaskResponse<T> : ErrorResponse where T : ITaskResponse
{
    [JsonRequired]
    [JsonProperty("status")]
    public string Status { get; set; } = null!;

    [JsonProperty("solution", NullValueHandling = NullValueHandling.Include)]
    public T? Solution { get; set; }

    [JsonRequired]
    [JsonProperty("taskId")]
    public string TaskId { get; set; } = null!;
}