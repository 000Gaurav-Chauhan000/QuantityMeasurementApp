using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public  class QuantityLength
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
            return Value * Unit.ToFeetFactor();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj is not QuantityLength other) return false;

            double a = ConvertToFeet();
            double b = other.ConvertToFeet();
            return Math.Abs(a - b) <= Tolerance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ConvertToFeet());
        }

        public static bool operator ==(QuantityLength? left, QuantityLength? right) =>
            left is null ? right is null : left.Equals(right);

        public static bool operator !=(QuantityLength? left, QuantityLength? right) =>
            !(left == right);
    }
}