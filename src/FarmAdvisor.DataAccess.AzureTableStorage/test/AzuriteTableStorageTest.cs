using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using FarmAdvisorApi.Models;
using Microsoft.WindowsAzure.Storage.Table;


namespace StonePorch.Tests.Mocks
{
    /// <summary>
    /// In-memory mock for ICloudTableStorage (extracted from Azure Table Storage). Enables fast unit testing without needing to run a CloudStorageAccount client.
    /// You can inject this mock into ReliableCloudTableRepository etc.
    /// NOTE: This isn't intended to test Table Storage serialization,
    ///       so be aware that your object might be stored successfully here but still fail to serialize in Azure.
    /// Further improvements: error handling eg if PartitionKey or RowKey are not set on an Entity.
    /// Originally from https://gist.github.com/timiles/4078750#file-inmemorytablestorage-cs
    /// </summary>
    public class AzuriteTableStorageTest : IAzuritTableStorage
    {
        private readonly Dictionary<string, Dictionary<string, Dictionary<string, object>>> _tables =
            new Dictionary<string, Dictionary<string, Dictionary<string, object>>>();

        /// <summary>
        /// Creates a new table if it does not already exist.
        /// 
        /// </summary>
        /// <param name="tableName">The name of the table to be created.</param>
        /// <returns>
        /// A flag indicating whether or not the table has actually been created.
        /// </returns>
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

        Task<SensorEntity> IAzuritTableStorage.CreateTable(string category, string id)
        {
            throw new NotImplementedException();
        }

        Task<SensorEntity> IAzuritTableStorage.DeleteTable(string tableName)
        {
            throw new NotImplementedException();
        }

        Task<SensorEntity> IAzuritTableStorage.TableExists(string tableName)
        {
            throw new NotImplementedException();
        }

        Task<SensorEntity> IAzuritTableStorage.Update<T>(string tableName, T entity)
        {
            throw new NotImplementedException();
        }

        Task<SensorEntity> IAzuritTableStorage.Upsert<T>(string tableName, T entity, bool replace)
        {
            throw new NotImplementedException();
        }

        Task<SensorEntity> IAzuritTableStorage.Delete<T>(string tableName, T entity)
        {
            throw new NotImplementedException();
        }
    }
}