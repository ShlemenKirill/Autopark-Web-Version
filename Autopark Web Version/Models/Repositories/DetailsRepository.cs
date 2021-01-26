using Autopark_Web_Version.Models.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Repositories
{
    public class DetailsRepository : IDetailsRepository<Details>, IDisposable
    {
        readonly IDbConnection connection = null;
        public DetailsRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public async Task Create(Details entity)
        {
            var sqlQuery = $"INSERT INTO Details (DetailName) " +
                            "VALUES(@DetailName)";
            await connection.ExecuteAsync(sqlQuery, entity);
        }

        public async Task Delete(int id)
        {
            var sqlQuery = "DELETE FROM Details WHERE DetailId = @id";
            await connection.ExecuteAsync(sqlQuery, new { id });
        }

        public async Task<Details> Get(int id)
        {
            var detailById = await connection.QueryAsync<Details>("SELECT * FROM Details WHERE DetailId = @id", new { id });
            return detailById.FirstOrDefault();
        }

        public async Task<IEnumerable<Details>> GetAll()
        {
            return await connection.QueryAsync<Details>("SELECT * FROM Details");
        }

        public async Task Update(Details entity)
        {
            var sqlQuery = "UPDATE Details SET " +
                            "DetailName = @DetailName " +                            
                            "WHERE DetailId = @DetailId";
            await connection.ExecuteAsync(sqlQuery, entity);
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

        ~DetailsRepository()
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
