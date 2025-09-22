namespace SmartLighting.Api.DTOs
{
    // Zone information
    public record ZoneDto(
        string Id,
        string Name,
        bool Occupied,
        int LuxNow,
        int TargetLux,
        int Brightness,
        string Status
    );
    // Summary for monthly usage and all zones
    public record SummaryDto(
        int MonthKwh,
        IEnumerable<ZoneDto> Zones
    );
    // Reading input coming from frontend
    public record ReadingIn(
        string ZoneId,
        bool? Occupied,
        int? LuxNow
    );
}