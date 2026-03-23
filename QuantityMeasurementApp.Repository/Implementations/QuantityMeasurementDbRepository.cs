using System;
using Microsoft.Data.SqlClient;
using QuantityMeasurement.Model.Entities;
using QuantityMeasurementApp.Repository.Interfaces;

namespace QuantityMeasurementApp.Repository.Implementations
{
    public class QuantityMeasurementDbRepository : IQuantityMeasurementRepository
    {
        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=QuantityDB;Trusted_Connection=True;TrustServerCertificate=True";

        public void Save(QuantityMeasurementEntity entity)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = @"INSERT INTO Measurements 
                            (Operation, Input1, Input2, Result, IsError)
                            VALUES (@op, @i1, @i2, @res, @err)";

            using SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@op", entity.Operation);
            cmd.Parameters.AddWithValue("@i1", entity.Input1);
            cmd.Parameters.AddWithValue("@i2", entity.Input2);
            cmd.Parameters.AddWithValue("@res", entity.Result);
            cmd.Parameters.AddWithValue("@err", entity.IsError);

            cmd.ExecuteNonQuery();
        }

        public List<QuantityMeasurementEntity> GetAll()
        {
            var list = new List<QuantityMeasurementEntity>();

            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlCommand cmd = new SqlCommand("SELECT * FROM Measurements", con);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new QuantityMeasurementEntity
                {
                    Operation = reader["Operation"].ToString(),
                    Input1 = reader["Input1"].ToString(),
                    Input2 = reader["Input2"].ToString(),
                    Result = reader["Result"].ToString(),
                    IsError = Convert.ToBoolean(reader["IsError"])
                });
            }

            return list;
        }

        public void DeleteAll()
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using SqlCommand cmd = new SqlCommand("DELETE FROM Measurements", con);
            cmd.ExecuteNonQuery();
        }
    }
}