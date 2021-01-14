using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Collections;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VenicleRepository : IVenicleRepository<Venicles>
    {
        readonly IDbConnection connection = null;
        public VenicleRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        
        public  List<Venicles> GetAll()
        {            
            return connection.Query<Venicles>("SELECT * FROM Venicles").ToList();
            
        }
        public  void Create(Venicles entity)
        {
            
            var sqlQuery = $"INSERT INTO Venicles (VeniclesTypeId, Engine, ModelName,RegistrationNumber, Weight, Year, Color, Mileage,Tank) " +
                            "VALUES(@VeniclesTypeId, @Engine, @ModelName, @RegistrationNumber, @Weight, @Year, @Color, @Mileage, @Tank)";
            connection.Execute(sqlQuery, entity);
            
        }

        public  void Delete(int id)
        {
            
            var sqlQuery = "DELETE FROM Venicles WHERE VenicleId = @id";
            connection.Execute(sqlQuery, new { id });
            
        }

        public  Venicles Get(int id)
        {
            
            return connection.Query<Venicles>("SELECT * FROM Venicles WHERE VenicleId = @id", new { id }).FirstOrDefault();
            
        }
        
        public  void Update(Venicles entity)
        {
            
            var sqlQuery = "UPDATE Venicles SET " +
                            "VeniclesTypeId = @VeniclesTypeId, " +
                            "Engine = @Engine, " +
                            "ModelName = @ModelName, " +
                            "RegistrationNumber = @RegistrationNumber, " +
                            "Weight = @Weight, " +
                            "Year = @Year, " +
                            "Color = @Color, " +
                            "Mileage = @Mileage, " +
                            "Tank = @Tank " +
                            "WHERE VenicleId = @VenicleId";
            connection.Execute(sqlQuery, entity);                
            
        }

        public List<Venicles> SortBy(string order)
        {
            var str = order.Split("_");
            if (str.Length == 1)
            {
                return connection.Query<Venicles>($"SELECT * FROM Venicles ORDER BY {str[0]}").ToList();
            }
            return connection.Query<Venicles>($"SELECT * FROM Venicles ORDER BY {str[0]} {str[1]}").ToList();              
            
        }

        public double CalculateTaxPerMounth(int id)
        { 
            var venicle = connection.Query<Venicles>("SELECT * FROM Venicles WHERE VenicleId = @id", new { id }).FirstOrDefault();            
            var venicleTypeTax = connection.Query<VenicleType>($"SELECT * FROM VenicleType WHERE VenicleTypeId ={venicle.VeniclesTypeId}").FirstOrDefault();            
            return (venicle.Weight * 0.013) + (venicleTypeTax.VenicleTax * 1.0 * 30.0) + 5;
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

        ~VenicleRepository()
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
