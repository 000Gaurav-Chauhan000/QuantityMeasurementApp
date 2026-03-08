using QuantityMeasurementApp.Business.Interfaces;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Business.Services
{
    public class QuantityLengthUtility : IQuantityLength
    {
        public bool CheckEquality(double value1, LengthUnit unit1, double value2, LengthUnit unit2)
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(value1, unit1);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(value2, unit2);

            return q1.Equals(q2);
        }
    }
}