using System.Threading.Tasks;
using FundaDataCollector.Data.Models;

namespace FundaDataCollector.Data.Repositories;

public interface IPaginationControllerRepository
{
    Task<PaginationController> UpdateController(PaginationController paginationController);
    Task<PaginationController> GetController(bool hasTuin);
}