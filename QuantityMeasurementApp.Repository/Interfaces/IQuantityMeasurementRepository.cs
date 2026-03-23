using System.Collections.Generic;
using QuantityMeasurement.Model.Entities;

namespace QuantityMeasurementApp.Repository.Interfaces
{
    public interface IQuantityMeasurementRepository
    {
        void Save(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAll();
        void DeleteAll();
    }
}