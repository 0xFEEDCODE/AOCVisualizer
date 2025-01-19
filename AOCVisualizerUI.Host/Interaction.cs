using Abstractions;
using Newtonsoft.Json;

namespace AOCVisualizerUI.Host;

public static class Interaction
{
    public static async Task Visualize(this char[][] grid, PathData pathData)
    {
        var vcontroller = Program.hostBuilder.Services.GetRequiredService<VisualizerController>();

        var height = grid.Length;
        var width = grid[0].Length;

        var gd = new GridData { Width = width, Height = height };
        var gwpd = new GridWithPathData { GridData = gd, PathData = pathData };

        await vcontroller.TestCommand(JsonConvert.SerializeObject(gwpd));
    }
}