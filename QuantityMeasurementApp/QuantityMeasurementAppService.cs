using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
namespace QuantityMeasurementApp
{
    public class QuantityMeasurementAppService
    {
        public static bool AreFeetEqual(double feet1, double feet2)
        {
            Feet f1 = new Feet(feet1);
            Feet f2 = new Feet(feet2);

            return f1.Equals(f2);    
        }
        public static bool AreInchesEqual(double inch1, double inch2)
        {
            Inches i1 = new Inches(inch1);
            Inches i2 = new Inches(inch2);
            return i1.Equals(i2);
        }
        public static bool AreLengthsEqual(double v1, LengthUnit u1, double v2, LengthUnit u2)
        {
            var q1 = new QuantityLength(v1, u1);
            var q2 = new QuantityLength(v2, u2);
            return q1.Equals(q2);
        }

    }
}