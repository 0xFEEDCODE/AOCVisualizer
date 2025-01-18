namespace AOCVisualizerUI.Host;

public static class Interaction
{
    public static async Task Visualize(this char[][] grid)
    {
        var vcontroller = Program.hostBuilder.Services.GetRequiredService<VisualizerController>();
        await vcontroller.TestCommand("Visualize grid");
    }
}