using static ConsoleHelperLibrary.Classes.KeysHelper;

namespace ReadKeyTimeoutApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        ReadLineTimed("Timeout in five seconds", TimeOut);
    }
}