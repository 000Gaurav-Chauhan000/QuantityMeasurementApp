namespace QuantityMeasurement.Model.DTOs;

public class QuantityDTO
{
    public double Value { get; set; }
    public string Unit { get; set; }
    public override string ToString()
    {
        return base.ToString();
    }

}