using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using FarmAdvisorApi.Models;
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using Microsoft.WindowsAzure.Storage.Table;


namespace StonePorch.Tests.Mocks
{

    public class AzuriteTableStorageTest : IAzuritTableStorage
    {
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, object>>> _tables =
            new Dictionary<string, Dictionary<string, Dictionary<string, object>>>();


        /// Creates a new table if it does not already exist.

        public bool CreateTable(string tableName)
        {
            if (TableExists(tableName))
                return false;

            _tables.Add(tableName, new Dictionary<string, Dictionary<string, object>>());
            return true;
        }

        // Deletes a table if it exists.

        public bool DeleteTable(string tableName)
        {
            return _tables.Remove(tableName);
        }

        /// Checks whether the specified table exists.
        public bool TableExists(string tableName)
        {
            return _tables.ContainsKey(tableName);
        }


        // Adds the specified entity into the table.

        // True if the entity has been successfully added, otherwise False.

        public bool Add<T>(string tableName, T entity)
        {
            string partitionKey, rowKey;
            GetTableEntityKeys(entity, out partitionKey, out rowKey);
            var table = _tables[tableName];
            if (!table.ContainsKey(partitionKey))
            {
                table.Add(partitionKey, new Dictionary<string, object>());
            }
            if (table[partitionKey].ContainsKey(rowKey))
            {
                return false;
            }
            table[partitionKey].Add(rowKey, entity);
            return true;
        }

        // Updates the specified entity stored in the table.

        // True if the entity has been successfully updated, otherwise False.

        public bool Update<T>(string tableName, T entity)
        {
            string partitionKey, rowKey;
            GetTableEntityKeys(entity, out partitionKey, out rowKey);
            var table = _tables[tableName];
            if (!table.ContainsKey(partitionKey))
            {
                return false;
            }
            if (!table[partitionKey].ContainsKey(rowKey))
            {
                return false;
            }
            table[partitionKey][rowKey] = entity;
            return true;
        }



        // upserting checher
        /// True if the entity has been successfully updated or inserted, otherwise False.
        /// </returns>
        public bool Upsert<T>(string tableName, T entity, bool replace)
        {
            throw new NotImplementedException();
        }


        /// Deletes the specified entity stored in the table.

        // True if the entity has been successfully deleted, otherwise False.
        // </returns>
        public bool Delete<T>(string tableName, T entity)
        {
            string partitionKey, rowKey;
            GetTableEntityKeys(entity, out partitionKey, out rowKey);
            var table = _tables[tableName];
            if (!table.ContainsKey(partitionKey))
            {
                return false;
            }
            if (table[partitionKey].Remove(rowKey))
            {
                return true;
            }
            // Azure actually throws an exception if the entity doesn't exist
            throw new DataServiceRequestException("An error occurred while processing this request.",
                                                  new DataServiceClientException(@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
    <error xmlns=""http://schemas.microsoft.com/ado/2007/08/dataservices/metadata"">
    <code>ResourceNotFound</code>
    <message xml:lang=""en-GB"">The specified resource does not exist.</message>
    </error>", 404));
        }



        private static bool GetTableEntityKeys<T>(T entity, out string partitionKey, out string rowKey)
        {
            var tableEntity = (object)entity as TableEntity;
            if (tableEntity != null)
            {
                partitionKey = tableEntity.PartitionKey;
                rowKey = tableEntity.RowKey;
                return !string.IsNullOrEmpty(partitionKey);
            }

            // TODO
            throw new NotImplementedException("Can't get entity keys from type " + typeof(T).Name);
        }

        Task<CalculatedGddEntity> IAzuritTableStorage.UpsertEntityAsync(CalculatedGddEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<CalculatedGddEntity> IAzuritTableStorage.DeleteEntityAsync(string SensorId, string CalculatedGdd)
        {
            throw new NotImplementedException();
        }

        Task<CalculatedGddEntity> IAzuritTableStorage.GetEntityAsync<CalculatedGddEntity>(string SensorId, string CalculatedGdd)

        {
            throw new NotImplementedException();
        }

        Task<SensorDataStorageEntity> IAzuritTableStorage.UpsertEntityAsync(SensorDataStorageEntity entity)
        {
            throw new NotImplementedException();
        }



        Task<WeatherForecastEntity> IAzuritTableStorage.UpsertEntityAsync(WeatherForecastEntity entity)
        {
            throw new NotImplementedException();
        }





    }
}