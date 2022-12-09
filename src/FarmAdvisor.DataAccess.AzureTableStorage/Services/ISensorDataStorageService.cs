using FarmAdvisorApi.Models;
using System.Threading.Tasks;

namespace FarmAdvisor.DataAccess.AzureTableStorage.Services
{
    public interface ISensorDataStorage
    {
        Task<SensorEntity> GetEntityAsync(string category, string id);
        Task<SensorEntity> UpsertEntityAsync(SensorEntity entity);
        Task DeleteEntityAsync(string category, string id);
    }
}
