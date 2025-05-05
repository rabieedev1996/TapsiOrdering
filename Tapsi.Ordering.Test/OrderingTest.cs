using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tapsi.Ordering.Test;

public class OrderingTest
{
    private readonly HttpClient _client;

    public OrderingTest()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5032");
    }

    [Fact]
    public async Task CreateOrder_ShouldReturnSuccess()
    {
        var order = new
        {
            CustomerName = "Ali",
            TotalPrice = 100000.0
        };

        var content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/CreateOrder", content);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var jsonParse=JObject.Parse(result);    
        Assert.True(bool.Parse(jsonParse["IsSuccess"].ToString()));
    }

    [Fact]
    public async Task GetOrderById_ShouldReturnSuccess()
    {
        var orderId = "00000000-0000-0000-0000-000000000000"; // یک GUID معتبر اینجا بگذار

        var response = await _client.GetAsync($"/GetOrderById?orderId={orderId}");
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var jsonParse=JObject.Parse(result);    
        Assert.True(bool.Parse(jsonParse["IsSuccess"].ToString()));
    }

    [Fact]
    public async Task GetOrders_ShouldReturnSuccess()
    {
        var query = new
        {
            FromDate = "2024-01-01T00:00:00",
            ToDate = "2025-01-01T00:00:00",
            From = 0,
            Count = 10
        };

        var content = new StringContent(JsonSerializer.Serialize(query), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/Orders", content);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var jsonParse=JObject.Parse(result);    
        Assert.True(bool.Parse(jsonParse["IsSuccess"].ToString()));
    }
}
