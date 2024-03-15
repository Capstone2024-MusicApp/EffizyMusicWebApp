using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class PayPalService
    {
        //public async Task<string> CreateOrder(string returnUrl)
        //{
        //    try
        //    {
        //        // Your PayPal Environment and Client ID/Secret setup
        //        string clientId = "Af9rn3sOsNDtyCwBZRlcQl3yNy_pPEc69KOJ3uJ1Ql5jHsdsKQKUYxMThkd_YBXKDBrrr1ymmVWUWBq6";
        //        string clientSecret = "EBbCW4OQZKIKa-kBssHSCkrHXhSKH-GeLE9spVrbPCCGey6jCrjuRO2tHYcfnpTRiIuJNDIizVLMZoxh";

        //        // Create PayPal environment
        //        var environment = new SandboxEnvironment(clientId, clientSecret);

        //        // Create PayPal client
        //        var client = new PayPalHttpClient(environment);

        //        // Build order request body
        //        var orderRequest = BuildRequestBody(returnUrl);

        //        // Create order request
        //        var request = new OrdersCreateRequest();
        //        request.Prefer("return=representation");
        //        request.RequestBody(orderRequest);

        //        // Execute request
        //        var response = await client.Execute(request);

        //        if (response.StatusCode == HttpStatusCode.Created)
        //        {
        //            var result = response.Result<PayPalCheckoutSdk.Orders.Order>();
        //            Console.WriteLine("Order created with ID: " + result.Id);
        //            return result.Id;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Failed to create order: " + response.StatusCode);
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error creating PayPal order: " + ex.Message);
        //        return null;
        //    }
        //}

        //private OrderRequest BuildRequestBody(string returnUrl)
        //{
        //    var orderRequest = new OrderRequest()
        //    {
        //        ApplicationContext = new ApplicationContext()
        //        {
        //            BrandName = "Effizy",
        //            LandingPage = "BILLING",
        //            UserAction = "Make Payment",
        //            ReturnUrl = returnUrl
        //        },
        //        PurchaseUnits = new List<PurchaseUnitRequest>()
        //        {
        //            new PurchaseUnitRequest()
        //            {
        //                AmountWithBreakdown = new AmountWithBreakdown()
        //                {
        //                    CurrencyCode = "USD",
        //                    Value = "100.00" // Example amount
        //                }
        //            }
        //        }
        //    };
        //    return orderRequest;
        //}
    }
}
