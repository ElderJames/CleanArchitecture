using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AntDesign.Pro.Layout;
using CleanArchitecture.WebUI.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using CleanArchitecture.WebUI.Client.Identity;

namespace CleanArchitecture.WebUI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("CleanArchitecture.WebUI.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CleanArchitecture.WebUI.ServerAPI"));

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.ClientId = "antdesign";
                options.ProviderOptions.DefaultScopes.Add("profile");
                options.ProviderOptions.DefaultScopes.Add("offline_access");
                options.ProviderOptions.DefaultScopes.Add("openid");
                options.ProviderOptions.DefaultScopes.Add("userinfo");
            });

            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<LocalStorage>();
            builder.Services.AddScoped<AccessTokenService>();
            builder.Services.AddScoped<IdentityContext>();

            await builder.Build().RunAsync();
        }
    }
}