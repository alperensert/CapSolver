using Newtonsoft.Json;

namespace CapSolver.Models.Responses;

public class GeeTestV4Response
{
    [JsonProperty("captcha_id")]
    public string CaptchaId { get; set; }

    [JsonProperty("captcha_output")]
    public string CaptchaOutput { get; set; }

    [JsonProperty("gen_time")]
    public string GenTime { get; set; }

    [JsonProperty("lot_number")]
    public string LotNumber { get; set; }

    [JsonProperty("pass_token")]
    public string Token { get; set; }

    [JsonProperty("risk_type")]
    public string RiskType { get; set; }

}
