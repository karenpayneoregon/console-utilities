using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace BottomRightApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - bottom right";
        W.SetConsoleWindowPosition(W.AnchorWindow.Bottom | W.AnchorWindow.Right);
    }
}
