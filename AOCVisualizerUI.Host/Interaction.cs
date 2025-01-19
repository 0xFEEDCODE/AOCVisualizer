using Abstractions;
using Newtonsoft.Json;

namespace AOCVisualizerUI.Host;

public static class Interaction
{
    public static async Task Visualize(this char[][] grid)
    {
        var vcontroller = Program.hostBuilder.Services.GetRequiredService<VisualizerController>();

        var height = grid.Length;
        var width = grid[0].Length;
        var gd = new GridData { Width = width, Height = height };

        await vcontroller.TestCommand(JsonConvert.SerializeObject(gd));
    }
}