using System.Text.Json;
using HolidaysApp.Models;
using Nager.Date;
using Nager.Date.Model;
using static System.DateTime;
using PublicHoliday = HolidaysApp.Models.PublicHoliday;

namespace HolidaysApp.Classes;

public class Operations
{
    public static async Task GetHolidays(CountryCode countryCode = CountryCode.US)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(
            $"https://date.nager.at/api/v3/publicholidays/{Now.Year}/{countryCode}");

        if (response.IsSuccessStatusCode)
        {
            await using var json = await response.Content.ReadAsStreamAsync();

            // Distinct is used as there were duplicate entries
            var publicHolidays =
                JsonSerializer.Deserialize<PublicHoliday[]>(json, jsonSerializerOptions)
                    !.Distinct(PublicHoliday.DateComparer);

            var countryName = CountryCodesList().FirstOrDefault(x 
                => x.CountryCode == countryCode.ToString())!.Name;

            AnsiConsole.MarkupLine($"[yellow]Holidays for {countryName}[/]");

            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]Name[/]")
                .AddColumn("[b]Date[/]")
                .Alignment(Justify.Left)
                .BorderColor(Color.CadetBlue);

            foreach (var holiday in publicHolidays!)
            {

                if (holiday.Date > Now)
                {
                    table.AddRow($"[cyan]{holiday.Name}[/]", $"[white]{holiday.Date:MM/dd/yyyy}[/]");
                }
                else
                {
                    table.AddRow(holiday.Name, holiday.Date.ToString("MM/dd/yyyy"));
                }
            }
            
            AnsiConsole.Write(table);
        }
        
    }

    public static async Task LongWeekends(CountryCode countryCode = CountryCode.US)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"https://date.nager.at/api/v3/LongWeekend/{Now.Year}/{countryCode}");

        if (response.IsSuccessStatusCode)
        {
            await using var json = await response.Content.ReadAsStreamAsync();

            var longWeekends = JsonSerializer.Deserialize<LongWeekend[]>(json, jsonSerializerOptions);

            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]Start[/]")
                .AddColumn("[b]End[/]")
                .AddColumn("[b]Count[/]")
                .Alignment(Justify.Left)
                .BorderColor(Color.CadetBlue);

            foreach (var weekend in longWeekends!)
            {

                if (weekend.StartDate > Now)
                {
                    table.AddRow(
                        $"[cyan]{weekend.StartDate:MM/dd/yyyy}[/]",
                        weekend.EndDate.ToString("MM/dd/yyyy"),
                        weekend.DayCount.ToString());
                }
                else
                {
                    table.AddRow(
                        weekend.StartDate.ToString("MM/dd/yyyy"),
                        weekend.EndDate.ToString("MM/dd/yyyy"),
                        weekend.DayCount.ToString());
                }
            }

            var countryName = CountryCodesList().FirstOrDefault(x 
                => x.CountryCode == countryCode.ToString())!.Name;

            AnsiConsole.MarkupLine($"[yellow]Long weekends for {countryName}[/]");
            AnsiConsole.Write(table);

        }
    }

    /// <summary>
    /// Get a list of supported countries into a list of <see cref="CountryCodes"/>
    /// </summary>
    /// <remarks>
    /// <para>1. Read all line</para>
    /// <para>2. For each line, split at comma</para>
    /// <para>3. Create new item, set properties</para>
    /// </remarks>
    public static List<CountryCodes> CountryCodesList() =>
        File.ReadAllLines("CountryCodes.txt").Select(x =>
        {
            var parts = x.Split(',');
            return new CountryCodes() { Name = parts[0], CountryCode = parts[1] };
        }).ToList();
}