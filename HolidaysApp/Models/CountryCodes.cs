#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace HolidaysApp.Models;
public class CountryCodes
{
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public override string ToString() => $"{Name} ({CountryCode})";

}
