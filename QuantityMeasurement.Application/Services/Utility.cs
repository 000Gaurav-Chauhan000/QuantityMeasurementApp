using QuantityMeasurement.Business.Services;
using QuantityMeasurementApp.Model.Models;
using QuantityMeasurementApp.Model.Units;

namespace QuantityMeasurement.Application.Services
{
    public class Utility
    {
        private readonly QuantityAppService app = new QuantityAppService();

        public void HandleLength(int operation, Quantity<LengthUnit> q1, Quantity<LengthUnit> q2)
        {
            switch (operation)
            {
                case 1:
                    app.DemonstrateAddition(q1, q2);
                    break;

                case 2:
                    app.DemonstrateSubtraction(q1, q2);
                    break;

                case 3:
                    app.DemonstrateDivision(q1, q2);
                    break;

                case 4:
                    app.DemonstrateEquality(q1, q2);
                    break;

                default:
                    throw new ArgumentException("Invalid operation for Length");
            }
        }

        public void HandleWeight(int operation, Quantity<WeightUnit> q1, Quantity<WeightUnit> q2)
        {
            switch (operation)
            {
                case 1:
                    app.DemonstrateAddition(q1, q2);
                    break;

                case 2:
                    app.DemonstrateSubtraction(q1, q2);
                    break;

                case 3:
                    app.DemonstrateDivision(q1, q2);
                    break;

                case 4:
                    app.DemonstrateEquality(q1, q2);
                    break;

                default:
                    throw new ArgumentException("Invalid operation for Weight");
            }
        }

        public void HandleTemperature(int operation, Quantity<TemperatureUnit> q1, Quantity<TemperatureUnit> q2)
        {
            if (operation == 4)
                app.DemonstrateEquality(q1, q2);
            else
                throw new InvalidOperationException("Only comparison supported for Temperature");
        }

        public Quantity<LengthUnit> ConvertLength(Quantity<LengthUnit> quantity, LengthUnit targetUnit)
        {
            return quantity.ConvertTo(targetUnit);
        }

        public Quantity<WeightUnit> ConvertWeight(Quantity<WeightUnit> quantity, WeightUnit targetUnit)
        {
            return quantity.ConvertTo(targetUnit);
        }

        public Quantity<TemperatureUnit> ConvertTemperature(Quantity<TemperatureUnit> quantity, TemperatureUnit targetUnit)
        {
            return quantity.ConvertTo(targetUnit);
        }
    }
}