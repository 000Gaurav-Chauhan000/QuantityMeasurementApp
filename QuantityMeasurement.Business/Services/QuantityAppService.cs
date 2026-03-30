using System;
using QuantityMeasurementApp.Model.Units;
using QuantityMeasurementApp.Model.Models;
using QuantityMeasurementApp.Interfaces;
using QuantityMeasurement.Model.DTO;
using QuantityMeasurement.Business.Interfaces;

namespace QuantityMeasurement.Business.Services
{
    public class QuantityAppService:IQuantityAppService
    {
        // ---------------- DEMO METHODS ----------------

        public void DemonstrateEquality<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable
        {
            Console.WriteLine($"{first} == {second} -> {first.Equals(second)}");
        }

        public void DemonstrateConversion<U>(Quantity<U> quantity, U targetUnit) where U : IMeasurable
        {
            Console.WriteLine($"{quantity} -> {quantity.ConvertTo(targetUnit)}");
        }

        public void DemonstrateAddition<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable
        {
            Console.WriteLine($"{first} + {second} = {first.Add(second)}");
        }

        public void DemonstrateAddition<U>(Quantity<U> first, Quantity<U> second, U targetUnit) where U : IMeasurable
        {
            Console.WriteLine($"{first} + {second} = {first.Add(second, targetUnit)}");
        }

        public void DemonstrateSubtraction<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable
        {
            Console.WriteLine($"{first} - {second} = {first.Subtract(second)}");
        }

        public void DemonstrateDivision<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable
        {
            Console.WriteLine($"{first} / {second} = {first.Divide(second)}");
        }

        // ---------------- MAIN RUN ----------------

        public void Run()
        {
            var length1 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);
            var length2 = new Quantity<LengthUnit>(1, LengthUnit.FEET);

            Console.WriteLine("Length Equality");
            DemonstrateEquality(length1, length2);
        }

        // ---------------- BUSINESS METHODS ----------------

        public object Compare(QuantityDTO q1, QuantityDTO q2)
        {
            if (q1.Type != q2.Type)
                throw new Exception("Different types not allowed");

            return q1.Type switch
            {
                "Length" => new Quantity<LengthUnit>(q1.Value, ParseLength(q1.Unit))
                                .Equals(new Quantity<LengthUnit>(q2.Value, ParseLength(q2.Unit))),

                "Weight" => new Quantity<WeightUnit>(q1.Value, ParseWeight(q1.Unit))
                                .Equals(new Quantity<WeightUnit>(q2.Value, ParseWeight(q2.Unit))),

                _ => throw new Exception("Unsupported type")
            };
        }

        public object Convert(QuantityDTO q, string targetUnit)
        {
            return q.Type switch
            {
                "Length" => new Quantity<LengthUnit>(q.Value, ParseLength(q.Unit))
                                .ConvertTo(ParseLength(targetUnit)),

                "Weight" => new Quantity<WeightUnit>(q.Value, ParseWeight(q.Unit))
                                .ConvertTo(ParseWeight(targetUnit)),

                _ => throw new Exception("Unsupported type")
            };
        }

        public object Add(QuantityDTO q1, QuantityDTO q2, string targetUnit)
        {
            if (q1.Type != q2.Type)
                throw new Exception("Different types not allowed");

            return q1.Type switch
            {
                "Length" => new Quantity<LengthUnit>(q1.Value, ParseLength(q1.Unit))
                                .Add(new Quantity<LengthUnit>(q2.Value, ParseLength(q2.Unit)),
                                     ParseLength(targetUnit)),

                "Weight" => new Quantity<WeightUnit>(q1.Value, ParseWeight(q1.Unit))
                                .Add(new Quantity<WeightUnit>(q2.Value, ParseWeight(q2.Unit)),
                                     ParseWeight(targetUnit)),

                _ => throw new Exception("Unsupported type")
            };
        }

        public object Subtract(QuantityDTO q1, QuantityDTO q2, string targetUnit)
        {
            if (q1.Type != q2.Type)
                throw new Exception("Different types not allowed");

            return q1.Type switch
            {
                "Length" => new Quantity<LengthUnit>(q1.Value, ParseLength(q1.Unit))
                                .Subtract(new Quantity<LengthUnit>(q2.Value, ParseLength(q2.Unit)),
                                          ParseLength(targetUnit)),

                "Weight" => new Quantity<WeightUnit>(q1.Value, ParseWeight(q1.Unit))
                                .Subtract(new Quantity<WeightUnit>(q2.Value, ParseWeight(q2.Unit)),
                                          ParseWeight(targetUnit)),

                _ => throw new Exception("Unsupported type")
            };
        }

        public object Divide(QuantityDTO q1, QuantityDTO q2)
        {
            if (q1.Type != q2.Type)
                throw new Exception("Different types not allowed");

            return q1.Type switch
            {
                "Length" => new Quantity<LengthUnit>(q1.Value, ParseLength(q1.Unit))
                                .Divide(new Quantity<LengthUnit>(q2.Value, ParseLength(q2.Unit))),

                "Weight" => new Quantity<WeightUnit>(q1.Value, ParseWeight(q1.Unit))
                                .Divide(new Quantity<WeightUnit>(q2.Value, ParseWeight(q2.Unit))),

                _ => throw new Exception("Unsupported type")
            };
        }

        // ---------------- PARSERS ----------------
private LengthUnit ParseLength(string unit)
{
    return unit.ToLower() switch
    {
        "inches" => LengthUnit.INCHES,
        "feet" => LengthUnit.FEET,
        "yards" => LengthUnit.YARDS,
        "centimeters" => LengthUnit.CENTIMETERS,
        _ => throw new Exception("Invalid Length Unit")
    };
}
 private WeightUnit ParseWeight(string unit)
{
    return unit.ToLower() switch
    {
        "gram" => WeightUnit.GRAM,
        "kilogram" => WeightUnit.KILOGRAM,
        "pound" => WeightUnit.POUND,
        _ => throw new Exception("Invalid Weight Unit")
    };
}

        public void DemonstrateSubtraction<U>(Quantity<U> first, Quantity<U> second, U targetUnit) where U : IMeasurable
        {
            throw new NotImplementedException();
        }
    }
}