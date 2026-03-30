using System;

namespace QuantityMeasurement.Model.Entities
{
    public class QuantityMeasurementEntity
    {
        public int Id { get; set; }

        public string Operation { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Result { get; set; }
        public bool IsError { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}