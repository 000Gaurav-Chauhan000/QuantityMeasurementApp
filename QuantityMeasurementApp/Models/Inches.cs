namespace QuantityMeasurementApp.Models
{
    internal class Inches : IEquatable<Inches>
    {
        public double Data { get; }

        public Inches(double data)
        {
            if(data < 0)
            {
                throw new ArgumentException("Feet values can't be Negative !!");
            }
            Data = data;
        }       

        public bool Equals(Inches? other)
        {
            if (other is null) return false;
            return Data.CompareTo(other.Data) == 0;
        }

        public override bool Equals(object? obj) => Equals(obj as Inches);

        public override int GetHashCode() => Data.GetHashCode();
    }
}