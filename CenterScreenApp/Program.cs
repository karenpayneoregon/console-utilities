namespace CenterScreenApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        D.CenterLines(ConsoleColor.Yellow, 
            "Window is centered vertically and horizontally", "Press ENTER to exit");
        Console.ReadLine();
    }
}