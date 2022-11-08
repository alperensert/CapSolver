namespace CaptchaAI.Tests;

public class BaseMethodTests
{
    [Fact]
    public async void TestBalance()
    {
        var client = new CaptchaAIClient(Environment.GetEnvironmentVariable("APIKEY")!, false);
        float balance = await client.GetBalance();
        Assert.NotNull(balance);
        Assert.IsType<float>(balance);
        Assert.True(default (float) != balance);
    }

    [Fact]
    public async void TestPackages()
    {
        var client = new CaptchaAIClient(Environment.GetEnvironmentVariable("APIKEY")!, false);
        List<string?> packages = await client.GetPackages();
        Assert.NotNull(packages);
        Assert.IsType<List<string?>>(packages);
    }
}