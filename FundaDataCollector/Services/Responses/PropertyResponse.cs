using System;

namespace FundaDataCollector.Services.Responses;

public class PropertyResponse
{
    public Guid Id { get; set; }
    public int? MakelaarId { get; set; }
    public string? MakelaarNaam { get; set; }
}