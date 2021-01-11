using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VenicleTypeRepository : IRepository<VenicleType>
    {
        string connectionString = null;
        public VenicleTypeRepository(string conn)
        {
            connectionString = conn;
        }
        public List<VenicleType> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<VenicleType>("SELECT * FROM VenicleType").ToList();
            }
        }
        public void Create(VenicleType entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Venicles (Engine, ModelName,RegistrationNumber, Weight, Year, Color, Mileage,Tank) " +
                    "VALUES(@Engine, @ModelName, @RegistrationNumber, @Weight, @Year, @Color, @Mileage, @Tank)";
                db.Execute(sqlQuery, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Venicles WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public VenicleType Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<VenicleType>("SELECT * FROM Venicles WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Update(VenicleType entity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, entity);
            }
        }

    }
}
