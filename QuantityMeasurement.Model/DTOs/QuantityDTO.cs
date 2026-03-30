namespace QuantityMeasurement.Model.DTO
{
    public class QuantityDTO
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; } // Length, Weight, Temperature
    }
}