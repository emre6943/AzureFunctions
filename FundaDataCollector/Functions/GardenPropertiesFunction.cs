using System;
using System.Threading.Tasks;
using FundaDataCollector.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FundaDataCollector.Functions;

public class GardenPropertiesFunction(IMyService myService, ILogger<GardenPropertiesFunction> logger)
{
    [Function("CollectGardenProperties")]
    public async Task Run([TimerTrigger("0 */2 * * * *")] TimerInfo myTimer)
    {
        try
        {
            logger.LogInformation("Garden properties collection started at: {Now}", DateTime.Now);
            await myService.FetchAndSaveProperties(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error collecting garden properties");
            throw;
        }
    }
}