using System;

namespace QuantityMeasurementApp.Interfaces
{
    public interface IMeasurable
    {
        double GetConversionFactor();
        double ConvertToBaseUnit(double value);
        double ConvertFromBaseUnit(double baseValue);
        string GetUnitName();

        bool SupportsOperation(string operation)
        {
            return true;
        }

        void ValidateOperationSupport(string operation)
        {
            if (!SupportsOperation(operation))
                throw new InvalidOperationException($"{GetUnitName()} does not support {operation} operation.");
        }
    }
}