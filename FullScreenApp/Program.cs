namespace FullScreenApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        D.CenterLines(
            ConsoleColor.Cyan, 
            "Window is full screen but not covering the task-bar",
            "Press ENTER to leave");

        Console.ReadLine();
    }
}