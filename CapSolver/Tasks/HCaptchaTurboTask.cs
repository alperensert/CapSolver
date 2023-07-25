namespace CapSolver.Tasks;

public class HCaptchaTurboTask : HCaptchaTask
{
    public HCaptchaTurboTask(string websiteUrl, string websiteKey, 
        object? enterprisePayload = null, bool? isEnterprise = null, 
        bool? isInvisible = null, string? userAgent = null) 
        : base(websiteUrl, websiteKey, enterprisePayload, isEnterprise, isInvisible, userAgent)
    {
        Type = "HCaptchaTurboTask";
    }
}