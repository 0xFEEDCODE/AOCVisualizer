using AOCVisualizerUI.Host;

public class Program
{
    private static readonly ManualResetEvent ExitEvent = new(false);

    private static async Task Main(string[] args)
    {
        Task.Factory.StartNew(async () =>
        {
            await AOCVisualizerUI.Host.Program.Main(null);
            ExitEvent.Set();
        });

        while (true)
        {
            await Task.Delay(1000);
            var grid = Array.Empty<char[]>();
            await grid.Visualize();
        }

        ExitEvent.WaitOne();
    }
}