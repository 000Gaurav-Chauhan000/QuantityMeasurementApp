using QuantityMeasurementApp.Model.Units;
using QuantityMeasurementApp.Model.Models;
using QuantityMeasurementApp.Interfaces;

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

        void Run();
    }
}