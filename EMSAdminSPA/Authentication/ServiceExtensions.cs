// Disclosure - the ParseClaimsFromJwt method is borrowed from Steve Sandersons Mission Control app
// Link: https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo/tree/master/demos/MissionControl

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EMSAdminSPA.Authentication
{
    public static class ServiceExtensions
    {
        public static void AddTokenAuthenticationStateProvider(this IServiceCollection services)
        {
            // Make the same instance accessible as both AuthenticationStateProvider and ApiAuthenticationStateProvider
            services.AddScoped<ApiAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<ApiAuthenticationStateProvider>());
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}