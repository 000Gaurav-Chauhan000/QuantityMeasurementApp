using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class QuantityWeight
    {
        private const double Tolerance = 1e-6;

        public double Value { get; }
        public WeightUnit Unit { get; }

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number.", nameof(value));

            Value = value;
            Unit = unit;
        }

        public double ConvertToKilogram()
        {
            return Unit.ConvertToBaseUnit(Value);
        }

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            double inKilogram = Unit.ConvertToBaseUnit(Value);
            double resultValue = targetUnit.ConvertFromBaseUnit(inKilogram);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public static QuantityWeight Convert(double value, WeightUnit sourceUnit, WeightUnit targetUnit)
        {
            double inKilogram = sourceUnit.ConvertToBaseUnit(value);
            double resultValue = targetUnit.ConvertFromBaseUnit(inKilogram);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            return Add(other, this.Unit);
        }

        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            double sumKilogram = this.Unit.ConvertToBaseUnit(this.Value) +
                                 other.Unit.ConvertToBaseUnit(other.Value);

            double resultValue = targetUnit.ConvertFromBaseUnit(sumKilogram);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public static QuantityWeight Add(QuantityWeight a, QuantityWeight b, WeightUnit targetUnit)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));

            double sumKilogram = a.Unit.ConvertToBaseUnit(a.Value) +
                                 b.Unit.ConvertToBaseUnit(b.Value);

            double resultValue = targetUnit.ConvertFromBaseUnit(sumKilogram);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not QuantityWeight other) return false;

            return Math.Abs(
                this.Unit.ConvertToBaseUnit(this.Value) -
                other.Unit.ConvertToBaseUnit(other.Value)
            ) <= Tolerance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Unit.ConvertToBaseUnit(Value));
        }

        public static bool operator ==(QuantityWeight? left, QuantityWeight? right) =>
            left is null ? right is null : left.Equals(right);

        public static bool operator !=(QuantityWeight? left, QuantityWeight? right) =>
            !(left == right);

        public override string ToString()
        {
            return $"QuantityWeight(Value={Value}, Unit={Unit})";
        }
    }
}