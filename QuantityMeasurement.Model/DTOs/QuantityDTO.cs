namespace QuantityMeasurement.Model.DTO;

public class QuantityDTO
{
    public double Value { get; set; }
    public string Unit { get; set; }

    public override string ToString()
    {
        return $"{Value} {Unit}";
    }
}