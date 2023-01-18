using FarmAdvisorApi.Models;
using System.Threading.Tasks;
namespace FarmAdvisor.DataAccess.AzureTableStorage.Services
{
    // building an interface for crud operation of The CalculatedGdd Table
    public interface ICalculatedGddService
    {
        Task<CalculatedGddEntity> GetEntityAsync(string SensorId, string CalculatedGdd);

        // upsert includes both creating and updating
        Task<CalculatedGddEntity> UpsertEntityAsync(CalculatedGddEntity entity);
        Task DeleteEntityAsync(string SensorId, string CalculatedGdd);
    }
}
