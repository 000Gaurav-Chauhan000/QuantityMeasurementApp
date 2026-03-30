using QuantityMeasurementApp.Model.Units;
using QuantityMeasurementApp.Model.Models;
using QuantityMeasurementApp.Interfaces;
using QuantityMeasurement.Model.DTO;

namespace QuantityMeasurement.Business.Interfaces
{
    public interface IQuantityAppService
    {
        void DemonstrateEquality<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable;

        void DemonstrateConversion<U>(Quantity<U> quantity, U targetUnit) where U : IMeasurable;

        void DemonstrateAddition<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable;

        void DemonstrateAddition<U>(Quantity<U> first, Quantity<U> second, U targetUnit) where U : IMeasurable;

        void DemonstrateSubtraction<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable;

        void DemonstrateSubtraction<U>(Quantity<U> first, Quantity<U> second, U targetUnit) where U : IMeasurable;

        void DemonstrateDivision<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable;
        object Compare(QuantityDTO q1, QuantityDTO q2);
        object Convert(QuantityDTO q, string targetUnit);
        object Add(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        object Subtract(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        object Divide(QuantityDTO q1, QuantityDTO q2);

        void Run();
    }
}