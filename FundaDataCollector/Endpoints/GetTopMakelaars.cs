using System;
using System.Net;
using System.Threading.Tasks;
using FundaDataCollector.Data.Repositories;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace FundaDataCollector.Endpoints;

public class GetTopMakelaars(IPropertyRepository propertyRepository)
{
    [Function("GetTopMakelaars")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        try
        {
            bool? hasTuin = bool.TryParse(req.Query["hasTuin"], out bool hasTuinValue) ? hasTuinValue : null;
            int top = int.TryParse(req.Query["top"], out var numberOfMakelaars) ? numberOfMakelaars : 10;
            
            var topMakelaars = await propertyRepository.GetTopMakelaarsAsync(hasTuin, top);
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(topMakelaars);
            return response;
        }
        catch (Exception ex)
        {
            var response = req.CreateResponse(HttpStatusCode.InternalServerError);
            await response.WriteStringAsync("Error processing request");
            return response;
        }
    }
}