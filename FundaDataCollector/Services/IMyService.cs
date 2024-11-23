using System.Threading.Tasks;

namespace FundaDataCollector.Services;

public interface IMyService
{
    Task FetchAndSaveProperties(bool hasTuin);
}