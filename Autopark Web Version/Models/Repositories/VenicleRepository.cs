using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VenicleRepository : IRepository<Venicles>
    {
        string connectionString = null;
        public VenicleRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Venicles> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Venicles>("SELECT * FROM Venicles").ToList();
            }
        }
        public void Create(Venicles entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Venicles (VeniclesTypeId, Engine, ModelName,RegistrationNumber, Weight, Year, Color, Mileage,Tank) " +
                    "VALUES(@VeniclesTypeId, @Engine, @ModelName, @RegistrationNumber, @Weight, @Year, @Color, @Mileage, @Tank)";
                db.Execute(sqlQuery, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Venicles WHERE VenicleId = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Venicles Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Venicles>("SELECT * FROM Venicles WHERE VenicleId = @id", new { id }).FirstOrDefault();
            }
        }
        
        public void Update(Venicles entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
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
                db.Execute(sqlQuery, entity);                
            }
        }
    }
}
