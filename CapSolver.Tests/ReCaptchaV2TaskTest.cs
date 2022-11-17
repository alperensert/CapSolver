namespace CapSolver.Tests;

public class ReCaptchaV2TaskTest
{
    [Fact]
    public async void Test()
    {
        var client = new CapSolverClient(Environment.GetEnvironmentVariable("APIKEY")!, false);
        var task = new ReCaptchaV2Task("https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                                       "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd");
        string id = await client.CreateTask(task);
        Assert.IsType<string>(id);
        Assert.NotNull(id);
        var response = await client.JoinTaskResult<ReCaptchaV2Response>(id);
        Assert.NotNull(response.GReCaptchaResponse);
        Assert.IsType<string>(response.GReCaptchaResponse);
    }
}