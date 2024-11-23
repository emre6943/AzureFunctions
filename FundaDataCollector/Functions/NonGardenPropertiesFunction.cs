using System;
using System.Threading.Tasks;
using FundaDataCollector.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FundaDataCollector.Functions;

public class NonGardenPropertiesFunction(IMyService myService, ILogger<NonGardenPropertiesFunction> logger)
{
    [Function("CollectNonGardenProperties")]
    public async Task Run([TimerTrigger("0 */3 * * * *")] TimerInfo myTimer)
    {
        try
        {
            logger.LogInformation("Non-garden properties collection started at: {Now}", DateTime.Now);
            await myService.FetchAndSaveProperties(false);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error collecting non-garden properties");
            throw;
        }
    }
}