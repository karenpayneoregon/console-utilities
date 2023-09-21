using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace DisableCloseButtonApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        ConsoleMenu.DisableCloseButton();
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
