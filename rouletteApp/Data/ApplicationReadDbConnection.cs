using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System;
using Dapper;
using Microsoft.Data.Sqlite;

namespace rouletteApp.Data
{
    public class ApplicationReadDbConnection : IApplicationReadDbConnection, IDisposable
    {
        private readonly IDbConnection connection;
        public ApplicationReadDbConnection(IConfiguration configuration)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = configuration.GetConnectionString("DefaultConnection") };
            var connectionString = connectionStringBuilder.ToString();
            connection = new SqliteConnection(connectionString);
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
