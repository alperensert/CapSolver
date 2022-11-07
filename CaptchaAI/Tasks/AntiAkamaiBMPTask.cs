using CaptchaAI.Utilities;
using Newtonsoft.Json;

namespace CaptchaAI.Tasks;

/// <summary>
/// This task type is used to solve Akamai BMP.
/// </summary>
public class AntiAkamaiBMPTask : ITask
{
    /// <summary>
    /// Task's type.
    /// </summary>
    [JsonProperty("type")]
    private readonly string Type = "AntiAkamaiBMPTask";

    /// <summary>
    /// Package name of AkamaiBMP mobile APP
    /// </summary>
    [JsonRequired]
    [JsonProperty("packageName")]
    public string PackageName { get; set; }

    /// <summary>
    /// AKAMAI BMP Version number, default is: 3.2.6 , max support is: 3.3.1
    /// </summary>
    [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
    public string? Version { get; set; }

    /// <summary>
    /// If you want to have a fixed device ID in the sensor, you can pass this parameter
    /// </summary>
    [JsonProperty("deviceId", NullValueHandling = NullValueHandling.Ignore)]
    public string? DeviceId { get; set; }

    /// <summary>
    /// Input fixed deviceInfo, default is: random.
    /// </summary>
    [JsonProperty("deviceName", NullValueHandling = NullValueHandling.Ignore)]
    public string? DeviceName { get; set; }

    /// <summary>
    /// Sensor combinations acquired at once. <br/>
    /// Maximum is 50.
    /// </summary>
    /// <value></value>
    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public int? Count { get; set; }

    /// <summary>
    /// Prepare AntiAkamaiBMP task.
    /// </summary>
    /// <param name="packageName">Package name of AkamaiBMP mobile APP</param>
    /// <param name="version">AKAMAI BMP Version number, default is: 3.2.6 , max support is: 3.3.1</param>
    /// <param name="deviceId">If you want to have a fixed device ID in the sensor, you can pass this parameter</param>
    /// <param name="deviceName">Input fixed deviceInfo, default is: random.</param>
    /// <param name="count">Sensor combinations acquired at once.</param>
    public AntiAkamaiBMPTask(string packageName,
                             string? version = null,
                             string? deviceId = null,
                             string? deviceName = null,
                             int? count = null)
    {
        PackageName = packageName;
        Version = version;
        DeviceId = deviceId;
        DeviceName = deviceName;
        Count = count;
    }

}