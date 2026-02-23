namespace QuantityMeasurementApp.Enums
{
    public enum LengthUnit
    {
        FEET,
        INCHES,
        YARDS,
        CENTIMETERS
    }

    public static class LengthUnitExtensions
    {
        public static double ToFeetFactor(this LengthUnit unit) => unit switch
        {
            LengthUnit.FEET => 1.0,
            LengthUnit.INCHES => 1.0 / 12.0,
            LengthUnit.YARDS => 3.0,
            LengthUnit.CENTIMETERS => 0.393701 / 12.0,
            _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Unsupported length unit")
        };
    }
}
