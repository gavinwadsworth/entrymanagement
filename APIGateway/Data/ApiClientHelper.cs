using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIGateway.Data
{
    public class ApiClientHelper
    {
        private readonly ILogger<ApiClientHelper> _logger;

        public ApiClientHelper(ILogger<ApiClientHelper> logger)
        {
            _logger = logger;
        }
        public static HttpClient ApiClient { get; set; }
        public static void Init()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public static async Task GetTokenAsync()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            

            //// Perform authentication setup
            //AuthenticationConfiguration authenticationConfiguration = AuthenticationConfiguration.ReadJsonFromFile("appsettings.json");

            //Console.WriteLine($"Authority:{authenticationConfiguration.Authority}");

            //// Aquire the token
            //IConfidentialClientApplication app;

            //app = ConfidentialClientApplicationBuilder.Create(authenticationConfiguration.ClientId)
            //    .WithClientSecret(authenticationConfiguration.ClientSecret)
            //    .WithAuthority(new Uri(authenticationConfiguration.Authority))
            //    .Build();

            //string[] ResourceIds = new string[] { authenticationConfiguration.ResourceId };

            //AuthenticationResult result;

            //try
            //{
            //    result = await app.AcquireTokenForClient(ResourceIds).ExecuteAsync();
            //}
            //catch (MsalClientException e)
            //{
            //    throw new Exception(e.Message);
            //}
        }
    }
}
