namespace AOCVisualizerUI.Host;

public static class Program
{
    public static IHost hostBuilder;

    public static async Task Main(string[] args)
    {
        hostBuilder = CreateHostBuilder(args).Build();
        await hostBuilder.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}