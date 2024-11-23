using System.Threading.Tasks;
using FundaDataCollector.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FundaDataCollector.Data.Repositories;

public class PaginationControllerRepository(MyDbContext context) : IPaginationControllerRepository
{
    public async Task<PaginationController> UpdateController(PaginationController paginationController)
    {
        context.PaginationControllers.Update(paginationController);
        await context.SaveChangesAsync();
        return paginationController;    
    }

    public async Task<PaginationController> GetController(bool hasTuin)
    {
        return await context.PaginationControllers.FirstAsync(c => c.HasTuin == hasTuin);
    }
}