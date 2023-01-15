using kwetter_be_user.ComponentTest;
using Microsoft.Extensions.Configuration;

namespace kwetter_be_user.ComponentTest;

public class Tests
{
    private ComponentTestConfig TestConfig { get; set; } = new ComponentTestConfig();

    [OneTimeSetUp]
    public void InitialSetup()
    {
        TestConfig = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build()
            .GetSection("ComponentTests")
            .Get<ComponentTestConfig>();
    }

    [Test]
    public async Task ShouldReturnAListOfStaticValuesOnGetReqeust()
    {
        // Arrange
        var httpClient = new HttpClient { BaseAddress = new Uri(TestConfig.ServiceUri) };

        // Act
        var response = await httpClient.GetAsync("user/values");
        var responseJson = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

        // Assert
        Assert.That(responseJson, Is.EqualTo("[\"Value1\",\"Value2\",\"Value3\"]"));
    }
}