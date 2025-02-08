using Abstractions;
using AOCVisualizerUI.Host;

public class Program
{
    private static readonly ManualResetEvent ExitEvent = new(false);

    private static async Task Main()
    {
        Host.Initialize(null);
        Task.Factory.StartNew(async () =>
        {
            await Host.Instance?.StartAsync();
            ExitEvent.Set();
        });

        while (true)
        {
            await Task.Delay(1000);
            var rand = new Random();

            var grid = Enumerable.Range(0, Math.Max(1, rand.Next(10))).Select(_ =>
                Enumerable.Range(0, Math.Max(1, rand.Next(10))).Select(_ => 'a').ToArray()).ToArray();

            await grid.Visualize(new PathData
            {
                StartPoint = new Point2D(GetRandC(), GetRandR()),
                EndPoint = new Point2D(GetRandC(), GetRandR())
            });

            continue;

            //get random col
            int GetRandC() => new Random().Next(0, grid[0].Length);
            // get random row
            int GetRandR() => new Random().Next(0, grid.Length);
        }

        ExitEvent.WaitOne();
    }
}