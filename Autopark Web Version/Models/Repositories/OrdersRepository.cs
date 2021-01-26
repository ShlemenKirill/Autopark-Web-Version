using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Repositories
{
    public class OrdersRepository : IOrdersRepository<Orders>, IDisposable
    {
        readonly IDbConnection connection = null;
        public OrdersRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }     

        public async Task<IEnumerable<Orders>> GetAll()
        {
            return await connection.QueryAsync<Orders>("SELECT * FROM Orders");
            
        }
        public async Task Create(Orders entity)
        {
            var sqlQuery = $"INSERT INTO Orders (VenicleId, Date) " +
                            "VALUES(@VenicleId, @Date)";
            await connection.ExecuteAsync(sqlQuery, entity);
        }
        public async Task<Orders> Get(int id)
        {
            var getOrderById = await connection.QueryAsync<Orders>("SELECT * FROM Orders WHERE OrderId = @id", new { id });
            return getOrderById.FirstOrDefault();
        }


        #region Disposable

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }

            if (disposing)
            {
                connection.Dispose();
            }

            _disposedValue = true;
        }

        ~OrdersRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        



        #endregion Disposable
    }
}
