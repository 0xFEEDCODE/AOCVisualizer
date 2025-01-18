using Microsoft.AspNetCore.ResponseCompression;

namespace AOCVisualizerUI.Host;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddSignalR();
        services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });

        services.AddTransient<VisualizerController>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseBlazorFrameworkFiles();
        app.UseResponseCompression();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToFile("index.html"); // Serve the Blazor WebAssembly app
            endpoints.MapHub<MessageHub>("/messageHub");
        });
    }
}