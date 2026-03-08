using System;
using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Models
{
    public class Quantity<U> where U : IMeasurable
    {
        public double Value { get; }
        public U Unit { get; }

        public Quantity(double value, U unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit), "Unit cannot be null");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite");

            Value = value;
            Unit = unit;
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentNullException(nameof(targetUnit), "Target unit cannot be null");

            double baseValue = Unit.ConvertToBaseUnit(Value);
            double convertedValue = targetUnit.ConvertFromBaseUnit(baseValue);
            convertedValue = Math.Round(convertedValue, 2);

            return new Quantity<U>(convertedValue, targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Other quantity cannot be null");

            double thisBaseValue = Unit.ConvertToBaseUnit(Value);
            double otherBaseValue = other.Unit.ConvertToBaseUnit(other.Value);
            double totalBaseValue = thisBaseValue + otherBaseValue;

            double resultValue = Unit.ConvertFromBaseUnit(totalBaseValue);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Other quantity cannot be null");

            if (targetUnit == null)
                throw new ArgumentNullException(nameof(targetUnit), "Target unit cannot be null");

            double thisBaseValue = Unit.ConvertToBaseUnit(Value);
            double otherBaseValue = other.Unit.ConvertToBaseUnit(other.Value);
            double totalBaseValue = thisBaseValue + otherBaseValue;

            double resultValue = targetUnit.ConvertFromBaseUnit(totalBaseValue);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, targetUnit);
        }
        public Quantity<U> Subtract(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Other quantity cannot be null");

            double thisBaseValue = Unit.ConvertToBaseUnit(Value);
            double otherBaseValue = other.Unit.ConvertToBaseUnit(other.Value);
            double totalBaseValue = thisBaseValue - otherBaseValue;

            double resultValue = Unit.ConvertFromBaseUnit(totalBaseValue);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, Unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Other quantity cannot be null");

            if (targetUnit == null)
                throw new ArgumentNullException(nameof(targetUnit), "Target unit cannot be null");

            double thisBaseValue = Unit.ConvertToBaseUnit(Value);
            double otherBaseValue = other.Unit.ConvertToBaseUnit(other.Value);
            double totalBaseValue = thisBaseValue - otherBaseValue;

            double resultValue = targetUnit.ConvertFromBaseUnit(totalBaseValue);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, targetUnit);
        }

        public double Divide(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Other quantity cannot be null");

            double thisBaseValue = Unit.ConvertToBaseUnit(Value);
            double otherBaseValue = other.Unit.ConvertToBaseUnit(other.Value);

            if (otherBaseValue == 0)
                throw new DivideByZeroException("Cannot divide by zero quantity");

            double result = thisBaseValue / otherBaseValue;
            return Math.Round(result, 2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Quantity<U> other))
                return false;

            if (Unit.GetType() != other.Unit.GetType())
                return false;

            double thisBaseValue = Math.Round(Unit.ConvertToBaseUnit(Value), 6);
            double otherBaseValue = Math.Round(other.Unit.ConvertToBaseUnit(other.Value), 6);

            return thisBaseValue == otherBaseValue;
        }

        public override int GetHashCode()
        {
            double baseValue = Math.Round(Unit.ConvertToBaseUnit(Value), 6);
            return HashCode.Combine(baseValue, typeof(U));
        }

        public override string ToString()
        {
            return $"{Value} {Unit.GetUnitName()}";
        }
    }
}