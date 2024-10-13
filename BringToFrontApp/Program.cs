using static BringToFrontApp.Classes.SpectreConsoleHelpers;
using static ConsoleHelperLibrary.Classes.WindowUtility;

namespace BringToFrontApp;

internal partial class Program
{
    private static async Task Main()
    {
        SetConsoleWindowPosition(AnchorWindow.Center);
        AnsiConsole.MarkupLine($"[{Color.Yellow}]Minimizing[/]");
        await Task.Delay(2000);
        MinimizeConsoleWindow();
        await Task.Delay(2000);
        BringToFront();
        SetConsoleWindowPosition(AnchorWindow.Fill);
        AnsiConsole.MarkupLine($"[{Color.Aqua}]Ready[/]");
        ExitPrompt();
    }
}