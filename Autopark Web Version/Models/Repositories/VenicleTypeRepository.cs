using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VenicleTypeRepository : IVenicleTypeRepository<VenicleType>, IDisposable
    {        
        readonly IDbConnection connection = null;
        public VenicleTypeRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public List<VenicleType> GetAll()
        {            
            return connection.Query<VenicleType>("SELECT * FROM VenicleType").ToList();
        }
        public void Create(VenicleType entity)
        {
            
            var sqlQuery = "INSERT INTO Venicles (Engine, ModelName,RegistrationNumber, Weight, Year, Color, Mileage,Tank) " +
                "VALUES(@Engine, @ModelName, @RegistrationNumber, @Weight, @Year, @Color, @Mileage, @Tank)";
            connection.Execute(sqlQuery, entity);
        }

        public void Delete(int id)
        {            
            var sqlQuery = "DELETE FROM Venicles WHERE Id = @id";
            connection.Execute(sqlQuery, new { id });
        }

        public VenicleType Get(int id)
        {            
            return connection.Query<VenicleType>("SELECT * FROM Venicles WHERE Id = @id", new { id }).FirstOrDefault();
        }

        public void Update(VenicleType entity)
        {            
            var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
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

        ~VenicleTypeRepository()
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
