using HolidaysApp.Classes;

namespace HolidaysApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            try
            {
                await Operations.GetHolidays();
                await Operations.LongWeekends();
            }
            catch (Exception localException)
            {
                AnsiConsole.Clear();
                ExceptionHelpers.ColorWithCyanFuchsia(localException);
            }

            Console.ReadLine();
        }
    }
}