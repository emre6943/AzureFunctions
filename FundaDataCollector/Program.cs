using System;
using FundaDataCollector.Data;
using FundaDataCollector.Data.Repositories;
using FundaDataCollector.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FundaDataCollector;

public class Program
{
    public static void Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(services =>
            {
                services.AddHttpClient();
                services.AddLogging();
        
                services.AddDbContext<MyDbContext>(options =>
                    options.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString")));
        
                services.AddTransient<IMyService, MyService>();
                services.AddSingleton<IFundaApiService, FundaApiService>();
                services.AddScoped<IPropertyRepository, PropertyRepository>();
                services.AddScoped<IPaginationControllerRepository, PaginationControllerRepository>();
            })
            .Build();

        host.Run();
    }
}