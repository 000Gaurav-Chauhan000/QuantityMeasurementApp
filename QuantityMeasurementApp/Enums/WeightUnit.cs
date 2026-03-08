namespace QuantityMeasurementApp.Enums
{
    public enum WeightUnit
    {
        KILOGRAM,
        GRAM,
        POUND
    }

    public static class WeightUnitExtensions
    {
        public static double ToKilogramFactor(this WeightUnit unit) => unit switch
        {
            WeightUnit.KILOGRAM => 1.0,
            WeightUnit.GRAM => 0.001,
            WeightUnit.POUND => 0.453592,
            _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Unsupported weight unit")
        };

        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number.", nameof(value));

            return value * unit.ToKilogramFactor();
        }

        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            if (double.IsNaN(baseValue) || double.IsInfinity(baseValue))
                throw new ArgumentException("Value must be a finite number.", nameof(baseValue));

            return baseValue / unit.ToKilogramFactor();
        }
    }
}