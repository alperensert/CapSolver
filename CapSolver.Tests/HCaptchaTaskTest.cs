namespace CapSolver.Tests;

public class HCaptchaTaskTest
{
    [Fact]
    public async void Test()
    {
        var client = new CapSolverClient(Environment.GetEnvironmentVariable("APIKEY")!, false);
        var task = new HCaptchaTask("https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
                                    "472fc7af-86a4-4382-9a49-ca9090474471");
        string id = await client.CreateTask(task);
        Assert.IsType<string>(id);
        Assert.NotNull(id);
        var response = await client.JoinTaskResult<HCaptchaTaskResponse>(id);
        Assert.NotNull(response.GReCaptchaResponse);
        Assert.IsType<string>(response.GReCaptchaResponse);
    }
}