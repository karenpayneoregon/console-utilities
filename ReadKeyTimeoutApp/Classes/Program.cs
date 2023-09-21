using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ReadKeyTimeoutApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static TimeSpan TimeOut => new TimeSpan(0, 0, 0, 5);
}
