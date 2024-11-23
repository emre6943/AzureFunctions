namespace FundaDataCollector.Data.Models;

public record PaginationController(bool HasTuin, int PageSize)
{
    public int LastFetchedPage { get; set; }
};