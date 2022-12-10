using FarmAdvisor.DataAccess.MSSQL.Abstractions;

namespace FarmAdvisor.DataAccess.MSSQL.Test
{

    public static class Utils
    {
        public static void DeleteAll<T>(List<T> entities,  IGenericRepository<T> repository) where T : class
        {
            entities.ForEach(async entity => await repository.DeleteAsync(entity));
        }
    }
}