using CustomerManagement.DL.Database;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.DL.Database
{
    public class SQLiteDatabaseContext : IDatabaseContext
    {
        #region Field
        
        private readonly string _dbLocation;

        #endregion

        #region Constructor

        public SQLiteDatabaseContext(string dbLocation)
        {
            _dbLocation = dbLocation;
        }

        #endregion

        #region Method

        /// <summary>
        /// Tạo kết nối tới SQLite Database
        /// </summary>
        /// <returns></returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection($"Data Source={_dbLocation}");
            await connection.OpenAsync();
            return connection;
        }

        /// <summary>
        /// Thiết lập Database
        /// </summary>
        /// <returns></returns>
        /// Created by: TMSANG (03/07/2020)
        public async Task SetupAsync()
        {
            if (!File.Exists(_dbLocation))
            {
                File.Create(_dbLocation).Close();
                using var connection = await CreateConnectionAsync();
                await connection.ExecuteAsync("CREATE TABLE Customer (Id TEXT PRIMARY KEY NOT NULL, FullName TEXT NOT NULL);");
            }
        } 

        #endregion
    }
}
