
// ReSharper disable once CheckNamespace
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
namespace Holidays;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - Holidays";
        W.SetConsoleWindowPosition(W.AnchorWindow.Bottom | W.AnchorWindow.Right);
    }
}