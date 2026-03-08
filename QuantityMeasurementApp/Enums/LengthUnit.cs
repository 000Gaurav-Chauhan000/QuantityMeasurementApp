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
            LengthUnit.CENTIMETERS => 1.0 / 30.48,
            _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Unsupported unit")
        };

        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number.", nameof(value));

            return value * unit.ToFeetFactor();
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            if (double.IsNaN(baseValue) || double.IsInfinity(baseValue))
                throw new ArgumentException("Value must be a finite number.", nameof(baseValue));

            return baseValue / unit.ToFeetFactor();
        }
    }
}