using FarmAdvisorApi.Models;

namespace StonePorch.Tests.Mocks
{
    public interface IAzuritTableStorage
    {
        Task<SensorEntity> CreateTable(string category, string id);
        Task<SensorEntity> DeleteTable(string tableName);

        Task<SensorEntity> TableExists(string tableName);

        Task<SensorEntity> Update<T>(string tableName, T entity);

        Task<SensorEntity> Upsert<T>(string tableName, T entity, bool replace);

        Task<SensorEntity> Delete<T>(string tableName, T entity);
    }
}