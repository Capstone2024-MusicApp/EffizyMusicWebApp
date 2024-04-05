using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class PayPalService
    {
        private readonly HttpClient _httpClient;

        public PayPalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get order details from PayPal
        public async Task<OrderResponse> GetOrderAsync(string paymentId)
        {
            // Configure HttpClient with PayPal API endpoint and authentication
            _httpClient.BaseAddress = new Uri("https://api.sandbox.paypal.com");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "YOUR_ACCESS_TOKEN");

            // Make GET request to PayPal API to retrieve order details
            HttpResponseMessage response = await _httpClient.GetAsync($"/v2/checkout/orders/{paymentId}");

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response to OrderResponse object
                string jsonResponse = await response.Content.ReadAsStringAsync();
                OrderResponse orderResponse = JsonSerializer.Deserialize<OrderResponse>(jsonResponse);

                return orderResponse;
            }
            else
            {
                // Handle error response from PayPal API
                throw new HttpRequestException($"Failed to get order details from PayPal API. Status code: {response.StatusCode}");
            }
        }
    }

    // Sample classes to represent PayPal response
    public class OrderResponse
    {
        public ShippingDetail ShippingDetail { get; set; }
    }

    public class ShippingDetail
    {
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
    }

    public class Name
    {
        public string FullName { get; set; }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AdminArea2 { get; set; }
        public string AdminArea1 { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }

    public class Phone
    {
        public string Number { get; set; }
    }
}

