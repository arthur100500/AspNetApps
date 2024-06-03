using System.Text;
using CatPhotoApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;


namespace CatPhotoApiNUnit;

public class Tests
{
    private WebApplicationFactory<Program> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Test]
    public async Task Test()
    {
        // Arrange
        var client = _factory.
            WithWebHostBuilder(null).
            CreateClient();

        // Act
        var content = new StringContent("32", Encoding.UTF8, "application/json");

        var response = await client.PostAsync("api/post", content);

        var res = response.Content;

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }
}
