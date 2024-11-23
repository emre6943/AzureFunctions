using System;

namespace FundaDataCollector.Data.Models;

public record Property(Guid Id, int? MakelaarId, string? MakelaarName, bool HasTuin, DateTime CreatedAt)
{
    public string ToText()
    {
        return $"{Id} - {MakelaarId} - {MakelaarName} - {HasTuin}";
    }
}