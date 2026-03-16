namespace QuantityMeasurementApp.Model.Models
{
    internal class Feet : IEquatable<Feet>
    {
        public double Data { get; }

        public Feet(double data)
        {
            if(data < 0)
            {
                throw new ArgumentException("Feet values can't be Negative !!");
            }
            Data = data;
        }
       

        public bool Equals(Feet? other)
        {
            if (other is null) return false;
            return Data.CompareTo(other.Data) == 0;
        }

        public override bool Equals(object? obj) => Equals(obj as Feet);
    }
}