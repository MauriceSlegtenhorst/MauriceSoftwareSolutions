using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MSS.Presentation.Blazor.PWAClient.Components.Dialog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSS.Presentation.Blazor.PWAClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#body");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IDialogService, DialogService>();

            await builder.Build().RunAsync();
        }
    }
}
