using System.Collections.Generic;
using System.Threading.Tasks;
using FundaDataCollector.Data.Models;

namespace FundaDataCollector.Services;

public interface IFundaApiService
{
    Task<IEnumerable<Property>> GetPropertiesAsync(bool hasTuin, int page = 1, int pageSize = 25);
}