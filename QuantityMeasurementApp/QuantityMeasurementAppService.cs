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
    }
}