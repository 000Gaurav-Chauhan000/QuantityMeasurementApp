using System;
using QuantityMeasurement.Model.DTO;
using QuantityMeasurement.Model.Entities;
using QuantityMeasurementApp.Repository.Interfaces;

namespace QuantityMeasurementApp.Repository.Services
{
    public class QuantityMeasurementServiceImpl
    {
        private readonly IQuantityMeasurementRepository _repo;

        public QuantityMeasurementServiceImpl(IQuantityMeasurementRepository repo)
        {
            _repo = repo;
        }

        private void Save(string op, string i1, string i2, string result, bool isError = false)
        {
            _repo.Save(new QuantityMeasurementEntity
            {
                Operation = op,
                Input1 = i1,
                Input2 = i2,
                Result = result,
                IsError = isError
            });
        }

        public QuantityDTO Add(QuantityDTO q1, QuantityDTO q2)
        {
            try
            {
                double value = q1.Value + q2.Value;

                var result = new QuantityDTO
                {
                    Value = value,
                    Unit = q1.Unit
                };

                Save("ADD", q1.ToString(), q2.ToString(), result.ToString());

                return result;
            }
            catch (Exception ex)
            {
                Save("ADD", q1.ToString(), q2.ToString(), ex.Message, true);
                throw;
            }
        }
    }
}