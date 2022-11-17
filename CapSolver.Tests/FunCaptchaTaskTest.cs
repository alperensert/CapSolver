namespace CapSolver.Tests;

public class FunCaptchaTaskTest
{
    [Fact]
    public async void Test()
    {
        var client = new CapSolverClient(Environment.GetEnvironmentVariable("APIKEY")!, false);
        var task = new FunCaptchaTask("https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                                       "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                                       "https://funcaptcha.com/cdn/fc/js/e1379a4a27539beb3f01dc2fa6a9b7eba6276b59/standard/fc-litejs.js");
        string id = await client.CreateTask(task);
        Assert.IsType<string>(id);
        Assert.NotNull(id);
        var response = await client.JoinTaskResult<FunCaptchaTaskResponse>(id);
        Assert.NotNull(response.Token);
        Assert.IsType<string>(response.Token);
    }
}