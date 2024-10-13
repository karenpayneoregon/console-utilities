namespace BringToFrontApp.Classes;

public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Render(new Rule($"" +
                        $"[{Color.Yellow}]Press[/] [{Color.Cyan1}]ENTER[/] [{Color.Yellow}]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

}