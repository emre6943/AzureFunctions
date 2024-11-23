using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundaDataCollector.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundaDataCollector.Data.Repositories;

public class PropertyRepository(MyDbContext context): IPropertyRepository
{
    public async Task<IEnumerable<Property>> CreatePropertiesIfDoesntExistAsync(IEnumerable<Property> properties)
    {
        var enumerable = properties.ToList();
        var ids = enumerable.Select(x => x.Id).ToList();
        var existingProperties = await context.Properties.Where(x => ids.Contains(x.Id)).ToListAsync();

        foreach (var property in enumerable)
        {
            if (existingProperties.FirstOrDefault(x => x.Id == property.Id) != null) continue;
            context.Properties.Add(property);
        }
        await context.SaveChangesAsync();
        return existingProperties;
    }
    
    public async Task<Dictionary<string, int>> GetTopMakelaarsAsync(bool? hasTuin = null, int topNumberOfMakelaars = 10)
    {
        var query = context.Properties.AsQueryable().Where(x => x.MakelaarId != null);
        
        if (hasTuin is not null)
        {
            query = query.Where(p => p.HasTuin == hasTuin.Value);
        }

        return await query
            .GroupBy(p => p.MakelaarName)
            .Select(g => new { MakelaarName = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(topNumberOfMakelaars)
            .ToDictionaryAsync(x => x.MakelaarName ?? "Name Not Found", x => x.Count);
    }
}