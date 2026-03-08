using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Enums
{
    public sealed class VolumeUnit : IMeasurable
    {
        public static readonly VolumeUnit LITRE = new VolumeUnit("Litre", 1.0);
        public static readonly VolumeUnit MILLILITRE = new VolumeUnit("Millilitre", 0.001);
        public static readonly VolumeUnit GALLON = new VolumeUnit("Gallon", 3.78541);

        private readonly string unitName;
        private readonly double conversionFactor;

        private VolumeUnit(string unitName, double conversionFactor)
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