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
            var rand = new Random();
            await Task.Delay(1000);

            var grid = Enumerable.Range(0, 1 + rand.Next(10)).Select(_ =>
                Enumerable.Range(0, 1 + rand.Next(10)).Select(_ => 'a').ToArray()).ToArray();

            await grid.Visualize();
        }

        ExitEvent.WaitOne();
    }
}