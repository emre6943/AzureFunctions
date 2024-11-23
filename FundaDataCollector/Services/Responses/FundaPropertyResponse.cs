using System.Collections.Generic;

namespace FundaDataCollector.Services.Responses;

public class FundaPropertyResponse
{
    public IEnumerable<PropertyResponse>? Objects { get; set; }
    public int TotaalAantalObjecten { get; set; }
}

public class PageDetails
{
    public int AantalPaginas  { get; set; }
    public int HuidigePagina { get; set; }
}

