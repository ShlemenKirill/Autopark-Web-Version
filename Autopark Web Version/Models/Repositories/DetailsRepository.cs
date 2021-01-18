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
    public class DetailsRepository : IDetailsRepository, IDisposable
    {
        readonly IDbConnection connection = null;
        public DetailsRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public void Create(Details entity)
        {
            var sqlQuery = $"INSERT INTO Details (DetailName) " +
                            "VALUES(@DetailName)";
            connection.Execute(sqlQuery, entity);
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Details WHERE DetailId = @id";
            connection.Execute(sqlQuery, new { id });
        }

        public Details Get(int id)
        {
            return connection.Query<Details>("SELECT * FROM Details WHERE DetailId = @id", new { id }).FirstOrDefault();
        }

        public List<Details> GetAll()
        {
            return connection.Query<Details>("SELECT * FROM Details").ToList();
        }

        public void Update(Details entity)
        {
            var sqlQuery = "UPDATE Details SET " +
                            "DetailName = @DetailName, " +                            
                            "WHERE DetailId = @DetailId";
            connection.Execute(sqlQuery, entity);
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
