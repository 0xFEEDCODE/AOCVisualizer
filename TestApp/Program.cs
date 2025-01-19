using Abstractions;
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


            // get random row
            int getRandR()
            {
                var rand = new Random();
                return rand.Next(0, grid.Length);
            }

            //get random col
            int getRandC()
            {
                var rand = new Random();
                return rand.Next(0, grid[0].Length);
            }

            await grid.Visualize(new PathData
            {
                StartPoint = new Point2D(getRandC(), getRandR()),
                EndPoint = new Point2D(getRandC(), getRandR())
            });
        }

        ExitEvent.WaitOne();
    }
}