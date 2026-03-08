using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Services
{
    public class QuantityAppService
    {
        public void DemonstrateEquality<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable
        {
            Console.WriteLine(first + " == " + second + " -> " + first.Equals(second));
        }

        public void DemonstrateConversion<U>(Quantity<U> quantity, U targetUnit) where U : IMeasurable
        {
            Console.WriteLine(quantity + " -> " + quantity.ConvertTo(targetUnit));
        }

        public void DemonstrateAddition<U>(Quantity<U> first, Quantity<U> second) where U : IMeasurable
        {
            Console.WriteLine(first + " + " + second + " = " + first.Add(second));
        }

        public void DemonstrateAddition<U>(Quantity<U> first, Quantity<U> second, U targetUnit) where U : IMeasurable
        {
            Console.WriteLine(first + " + " + second + " = " + first.Add(second, targetUnit));
        }

        public void Run()
        {
            Quantity<LengthUnit> length1 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);
            Quantity<LengthUnit> length2 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            Quantity<LengthUnit> length3 = new Quantity<LengthUnit>(2, LengthUnit.YARDS);

            Quantity<WeightUnit> weight1 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);
            Quantity<WeightUnit> weight2 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            Quantity<WeightUnit> weight3 = new Quantity<WeightUnit>(2, WeightUnit.POUND);

            Console.WriteLine("Length Equality");
            DemonstrateEquality(length1, length2);

            Console.WriteLine();
            Console.WriteLine("Length Conversion");
            DemonstrateConversion(length3, LengthUnit.FEET);

            Console.WriteLine();
            Console.WriteLine("Length Addition");
            DemonstrateAddition(
                new Quantity<LengthUnit>(2, LengthUnit.FEET),
                new Quantity<LengthUnit>(24, LengthUnit.INCHES)
            );

            Console.WriteLine();
            Console.WriteLine("Weight Equality");
            DemonstrateEquality(weight1, weight2);

            Console.WriteLine();
            Console.WriteLine("Weight Conversion");
            DemonstrateConversion(weight3, WeightUnit.KILOGRAM);

            Console.WriteLine();
            Console.WriteLine("Weight Addition");
            DemonstrateAddition(
                new Quantity<WeightUnit>(2, WeightUnit.KILOGRAM),
                new Quantity<WeightUnit>(500, WeightUnit.GRAM)
            );
            Quantity<VolumeUnit> volume1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> volume2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);
            Quantity<VolumeUnit> volume3 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);

            Console.WriteLine();
            Console.WriteLine("Volume Equality");
            DemonstrateEquality(volume1, volume2);

            Console.WriteLine();
            Console.WriteLine("Volume Conversion");
            DemonstrateConversion(volume3, VolumeUnit.LITRE);

            Console.WriteLine();
            Console.WriteLine("Volume Addition");
            DemonstrateAddition(
                new Quantity<VolumeUnit>(1, VolumeUnit.LITRE),
                new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE)
            );

            Console.WriteLine();
            Console.WriteLine("Volume Addition With Target Unit");
            DemonstrateAddition(
                new Quantity<VolumeUnit>(1, VolumeUnit.LITRE),
                new Quantity<VolumeUnit>(1, VolumeUnit.GALLON),
                VolumeUnit.MILLILITRE
            );
        }
    }
}