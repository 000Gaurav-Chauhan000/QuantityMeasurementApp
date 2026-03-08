using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class QuantityLength
    {
        private const double Tolerance = 1e-9;

        public double Value { get; }
        public LengthUnit Unit { get; }

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number.", nameof(value));

            Value = value;
            Unit = unit;
        }

        public double ConvertToFeet()
        {
            return Unit.ConvertToBaseUnit(Value);
        }

        public double ConvertTo(LengthUnit targetUnit)
        {
            double inFeet = Unit.ConvertToBaseUnit(Value);
            return targetUnit.ConvertFromBaseUnit(inFeet);
        }

        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            double inFeet = sourceUnit.ConvertToBaseUnit(value);
            return targetUnit.ConvertFromBaseUnit(inFeet);
        }

        public QuantityLength Add(QuantityLength other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            return Add(other, this.Unit);
        }

        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            double sumFeet = this.Unit.ConvertToBaseUnit(this.Value) +
                             other.Unit.ConvertToBaseUnit(other.Value);

            double resultValue = targetUnit.ConvertFromBaseUnit(sumFeet);

            return new QuantityLength(resultValue, targetUnit);
        }

        public static QuantityLength Add(QuantityLength a, QuantityLength b, LengthUnit targetUnit)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            double sumFeet = a.Unit.ConvertToBaseUnit(a.Value) +
                             b.Unit.ConvertToBaseUnit(b.Value);

            double resultValue = targetUnit.ConvertFromBaseUnit(sumFeet);

            return new QuantityLength(resultValue, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not QuantityLength other) return false;

            return Math.Abs(
                this.Unit.ConvertToBaseUnit(this.Value) -
                other.Unit.ConvertToBaseUnit(other.Value)
            ) <= Tolerance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Unit.ConvertToBaseUnit(Value));
        }

        public static bool operator ==(QuantityLength? left, QuantityLength? right) =>
            left is null ? right is null : left.Equals(right);

        public static bool operator !=(QuantityLength? left, QuantityLength? right) =>
            !(left == right);
    }
}