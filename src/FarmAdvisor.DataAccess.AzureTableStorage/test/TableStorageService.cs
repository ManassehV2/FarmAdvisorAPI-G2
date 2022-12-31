namespace FarmAdvisor.Function.Test.DataAccess.AzureTableStorage
{
    internal class TableStorageService
    {
        private string tableName;
    

        public TableStorageService(string tableName)
        {
            this.tableName = tableName;
        }

        internal Task DeleteEntityAsync<T>(string partitionKey, string rowKey)
        {
            throw new NotImplementedException();
        }

        internal Task GetEntityAsync<T>(string partitionKey, string rowKey)
        {
            throw new NotImplementedException();
        }

        internal Task UpsertEntityAsync<T>(T weather)
        {
            throw new NotImplementedException();
        }
    }
}