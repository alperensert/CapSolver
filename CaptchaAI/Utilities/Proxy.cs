using Newtonsoft.Json;

namespace CaptchaAI.Utilities;

public class Proxy : IProxyTask
{
    [JsonProperty("proxyType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProxyType { get; set; }

    [JsonProperty("proxyAddress", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProxyAddress { get; set; }

    [JsonProperty("proxyPort", NullValueHandling = NullValueHandling.Ignore)]
    public int ProxyPort { get; set; }

    [JsonProperty("proxyLogin", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProxyLogin { get; set; }

    [JsonProperty("proxyPassword", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProxyPassword { get; set; }

    public Proxy(string proxyType,
                     string proxyAddress,
                     int proxyPort,
                     string? proxyLogin = null,
                     string? proxyPassword = null)
    {
        ProxyType = proxyType;
        ProxyAddress = proxyAddress;
        ProxyPort = proxyPort;
        ProxyLogin = proxyLogin;
        ProxyPassword = proxyPassword;
    }
}