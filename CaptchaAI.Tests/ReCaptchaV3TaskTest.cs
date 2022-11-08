namespace CaptchaAI.Tests;

public class ReCaptchaV3TaskTest
{
    [Fact]
    public async void Test()
    {
        var client = new CaptchaAIClient(Environment.GetEnvironmentVariable("APIKEY")!, false);
        var task = new ReCaptchaV3Task("https://lessons.zennolab.com/captchas/recaptcha/v3.php?level=beta",
                                       "6Le0xVgUAAAAAIt20XEB4rVhYOODgTl00d8juDob",
                                       "verify");
        string id = await client.CreateTask(task);
        Assert.IsType<string>(id);
        Assert.NotNull(id);
        var response = await client.JoinTaskResult<ReCaptchaV3Response>(id);
        Assert.NotNull(response.GReCaptchaResponse);
        Assert.IsType<string>(response.GReCaptchaResponse);
    }
}