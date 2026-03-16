using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Model.Units
{
    public sealed class LengthUnit : IMeasurable
    {
        public static readonly LengthUnit FEET = new LengthUnit("Feet", 1.0);
        public static readonly LengthUnit INCHES = new LengthUnit("Inches", 1.0 / 12.0);
        public static readonly LengthUnit YARDS = new LengthUnit("Yards", 3.0);
        public static readonly LengthUnit CENTIMETERS = new LengthUnit("Centimeters", 1.0 / 30.48);

        private readonly string unitName;
        private readonly double conversionFactor;

        private LengthUnit(string unitName, double conversionFactor)
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