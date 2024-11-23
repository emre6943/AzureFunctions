using System;
using System.Linq;
using System.Threading.Tasks;
using FundaDataCollector.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace FundaDataCollector.Services;

public class MyService(IFundaApiService fundaApiService, IPaginationControllerRepository controllerRepository, IPropertyRepository propertyRepository, ILogger<MyService> logger): IMyService
{
    public async Task FetchAndSaveProperties(bool hasTuin)
    {
        try
        {
            var paginationController = await controllerRepository.GetController(hasTuin);
            paginationController.LastFetchedPage+=1;
            
            var properties= (await fundaApiService.GetPropertiesAsync(hasTuin, page: paginationController.LastFetchedPage + 1, pageSize: paginationController.PageSize)).ToList();
            if (!properties.Any())
            {
                paginationController.LastFetchedPage = 0;
                await controllerRepository.UpdateController(paginationController);
                return;
            }
            
            await propertyRepository.CreatePropertiesIfDoesntExistAsync(properties);
            await controllerRepository.UpdateController(paginationController);
        }
        catch (Exception ex)
        {
            logger.LogError("An error occurred: {ExMessage}", ex.Message);
        }
    }
}