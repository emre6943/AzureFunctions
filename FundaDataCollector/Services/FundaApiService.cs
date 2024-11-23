using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FundaDataCollector.Data.Models;
using FundaDataCollector.Services.Responses;
using Microsoft.Extensions.Configuration;

namespace FundaDataCollector.Services;

public class FundaApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration): IFundaApiService
{
    private readonly string _apiKey = configuration["FundaApiKey"];
    private readonly string _baseUrl = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json";
    
    public async Task<IEnumerable<Property>> GetPropertiesAsync(bool hasTuin, int page = 1, int pageSize = 25)
    {
            var searchQuery = hasTuin ? "/tuin" : "";
            var url = $"{_baseUrl}/{_apiKey}//?type=koop&zo=/amsterdam{searchQuery}/&page={page}&pagesize={pageSize}";
            
            var httpClient = httpClientFactory.CreateClient(); 
            var response = await httpClient.GetAsync(url);

            var result = await response.Content.ReadFromJsonAsync<FundaPropertyResponse>();
            return result?.Objects?.Select(p => new Property(p.Id, p.MakelaarId, p.MakelaarNaam, hasTuin, DateTime.UtcNow)) ?? [];
    }
}