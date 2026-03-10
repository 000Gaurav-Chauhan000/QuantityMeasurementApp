using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.MeasurementUnits
{
    public sealed class WeightUnit : IMeasurable
    {
        public static readonly WeightUnit KILOGRAM = new WeightUnit("Kilogram", 1.0);
        public static readonly WeightUnit GRAM = new WeightUnit("Gram", 0.001);
        public static readonly WeightUnit POUND = new WeightUnit("Pound", 0.453592);

        private readonly string unitName;
        private readonly double conversionFactor;

        private WeightUnit(string unitName, double conversionFactor)
        {
            this.unitName = unitName;
            this.conversionFactor = conversionFactor;
        }

        public double GetConversionFactor()
        {
            return conversionFactor;
        }

        public double ConvertToBaseUnit(double value)
        {
            return value * conversionFactor;
        }

        public double ConvertFromBaseUnit(double baseValue)
        {
            return baseValue / conversionFactor;
        }

        public string GetUnitName()
        {
            return unitName;
        }

        public override string ToString()
        {
            return unitName;
        }
    }
}