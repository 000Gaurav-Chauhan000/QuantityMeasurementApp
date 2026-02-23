using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class QuantityLength
    {
        private readonly double _value;
        private readonly LengthUnit _unit;

        private const double INCH_TO_CM = 2.54;
        private const double EPSILON = 1e-6;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value", nameof(value));

            if (value < 0) throw new ArgumentException("Value cannot be negative", nameof(value));

            _value = value;
            _unit = unit;
        }

        public double Value => _value;
        public LengthUnit Unit => _unit;

        public QuantityLength Add(QuantityLength other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            double sumInches =
                ConvertToInches(_value, _unit) +
                ConvertToInches(other._value, other._unit);

            double resultValue = ConvertFromInches(sumInches, _unit);
            return new QuantityLength(resultValue, _unit);
        }

        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            double sumInches =
                ConvertToInches(_value, _unit) +
                ConvertToInches(other._value, other._unit);

            double resultValue = ConvertFromInches(sumInches, targetUnit);
            return new QuantityLength(resultValue, targetUnit);
        }

        public static QuantityLength Add(QuantityLength first, QuantityLength second)
        {
            if (first is null) throw new ArgumentNullException(nameof(first));
            if (second is null) throw new ArgumentNullException(nameof(second));

            return first.Add(second);
        }

        public static QuantityLength Add(QuantityLength a, QuantityLength b, LengthUnit targetUnit)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            return a.Add(b, targetUnit);
        }

        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double converted = Convert(_value, _unit, targetUnit);
            return new QuantityLength(converted, targetUnit);
        }

        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            double inches = ConvertToInches(value, source);
            return ConvertFromInches(inches, target);
        }

        private static double ConvertToInches(double value, LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.INCHES => value,
                LengthUnit.FEET => value * 12.0,
                LengthUnit.YARDS => value * 36.0,
                LengthUnit.CENTIMETERS => value / INCH_TO_CM,
                _ => throw new ArgumentException("Unsupported unit", nameof(unit))
            };
        }

        private static double ConvertFromInches(double inches, LengthUnit target)
        {
            return target switch
            {
                LengthUnit.INCHES => inches,
                LengthUnit.FEET => inches / 12.0,
                LengthUnit.YARDS => inches / 36.0,
                LengthUnit.CENTIMETERS => inches * INCH_TO_CM,
                _ => throw new ArgumentException("Unsupported unit", nameof(target))
            };
        }
        public override bool Equals(object? obj)
        {
            if (obj is not QuantityLength other)
                return false;

            double thisInches = ConvertToInches(_value, _unit);
            double otherInches = ConvertToInches(other._value, other._unit);

            return Math.Abs(thisInches - otherInches) < EPSILON;
        }

        public override int GetHashCode()
        {
            double inches = ConvertToInches(_value, _unit);
            long bucket = (long)Math.Round(inches / EPSILON);
            return bucket.GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({_value}, {_unit})";
        }
    }
}