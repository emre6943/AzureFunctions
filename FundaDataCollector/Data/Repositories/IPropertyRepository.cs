using System.Collections.Generic;
using System.Threading.Tasks;
using FundaDataCollector.Data.Models;

namespace FundaDataCollector.Data.Repositories;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> CreatePropertiesIfDoesntExistAsync(IEnumerable<Property> properties);
    Task<Dictionary<string, int>> GetTopMakelaarsAsync(bool? hasTuin = null, int topNumberOfMakelaars = 10);
}