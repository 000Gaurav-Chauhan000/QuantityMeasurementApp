using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.MeasurementUnits
{
    public sealed class TemperatureUnit : IMeasurable
    {
        public static readonly TemperatureUnit CELSIUS = new TemperatureUnit("Celsius");
        public static readonly TemperatureUnit FAHRENHEIT = new TemperatureUnit("Fahrenheit");
        public static readonly TemperatureUnit KELVIN = new TemperatureUnit("Kelvin");

        private readonly string unitName;

        private TemperatureUnit(string unitName)
        {
            this.unitName = unitName;
        }

        public double GetConversionFactor()
        {
            return 1.0;
        }

        public double ConvertToBaseUnit(double value)
        {
            if (this == CELSIUS)
                return value;

            if (this == FAHRENHEIT)
                return (value - 32) * 5 / 9.0;

            if (this == KELVIN)
                return value - 273.15;

            throw new InvalidOperationException("Invalid temperature unit");
        }

        public double ConvertFromBaseUnit(double baseValue)
        {
            if (this == CELSIUS)
                return baseValue;

            if (this == FAHRENHEIT)
                return (baseValue * 9 / 5.0) + 32;

            if (this == KELVIN)
                return baseValue + 273.15;

            throw new InvalidOperationException("Invalid temperature unit");
        }

        public string GetUnitName()
        {
            return unitName;
        }

        public bool SupportsOperation(string operation)
        {
            return operation == "EQUALS" || operation == "CONVERT";
        }

        public void ValidateOperationSupport(string operation)
        {
            if (!SupportsOperation(operation))
                throw new InvalidOperationException($"Temperature measurements do not support {operation} operation.");
        }

        public override string ToString()
        {
            return unitName;
        }
    }
}