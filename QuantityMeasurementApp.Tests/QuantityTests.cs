using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityTest
    {
        [TestMethod]
        public void GivenSameInches_WhenCompared_ShouldReturnTrue()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(4, LengthUnit.INCHES);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(4, LengthUnit.INCHES);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenDifferentInches_WhenCompared_ShouldReturnFalse()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(4, LengthUnit.INCHES);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(5, LengthUnit.INCHES);

            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenInchesAndFeet_WhenCompared_ShouldReturnTrue()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(1, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenFeetAndYards_WhenCompared_ShouldReturnTrue()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(3, LengthUnit.FEET);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(1, LengthUnit.YARDS);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenYards_WhenConvertedToFeet_ShouldReturnCorrectValue()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(2, LengthUnit.YARDS);

            Quantity<LengthUnit> result = q1.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(6, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void GivenCentimeters_WhenConvertedToFeet_ShouldReturnCorrectValue()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(30.48, LengthUnit.CENTIMETERS);

            Quantity<LengthUnit> result = q1.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void GivenTwoLengths_WhenAdded_ShouldReturnCorrectResultInFirstUnit()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(2, LengthUnit.FEET);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(24, LengthUnit.INCHES);

            Quantity<LengthUnit> result = q1.Add(q2);

            Assert.AreEqual(4, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void GivenTwoLengths_WhenAddedWithTargetUnit_ShouldReturnCorrectResult()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(1, LengthUnit.YARDS);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);

            Quantity<LengthUnit> result = q1.Add(q2, LengthUnit.FEET);

            Assert.AreEqual(4, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void GivenGramAndKilogram_WhenCompared_ShouldReturnTrue()
        {
            Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);
            Quantity<WeightUnit> q2 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenPound_WhenConvertedToKilogram_ShouldReturnCorrectValue()
        {
            Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(1, WeightUnit.POUND);

            Quantity<WeightUnit> result = q1.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(0.45, result.Value);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void GivenTwoWeights_WhenAdded_ShouldReturnCorrectResult()
        {
            Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(2, WeightUnit.KILOGRAM);
            Quantity<WeightUnit> q2 = new Quantity<WeightUnit>(500, WeightUnit.GRAM);

            Quantity<WeightUnit> result = q1.Add(q2);

            Assert.AreEqual(2.5, result.Value);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void GivenNullUnit_WhenCreatingQuantity_ShouldThrowArgumentNullException()
        {
            try
            {
                Quantity<LengthUnit> q = new Quantity<LengthUnit>(5, null);

                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void GivenNaNValue_WhenCreatingQuantity_ShouldThrowArgumentException()
        {
            try
            {
                Quantity<LengthUnit> q = new Quantity<LengthUnit>(double.NaN, LengthUnit.FEET);

                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void GivenInfinityValue_WhenCreatingQuantity_ShouldThrowArgumentException()
        {
            try
            {
                Quantity<LengthUnit> q = new Quantity<LengthUnit>(double.PositiveInfinity, LengthUnit.FEET);

                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void GivenSameLitres_WhenCompared_ShouldReturnTrue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenLitreAndMillilitre_WhenCompared_ShouldReturnTrue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenGallonAndLitre_WhenCompared_ShouldReturnTrue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenLitre_WhenConvertedToMillilitre_ShouldReturnCorrectValue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000, result.Value);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void GivenGallon_WhenConvertedToLitre_ShouldReturnCorrectValue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);

            Quantity<VolumeUnit> result = q1.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.79, result.Value);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void GivenMillilitre_WhenConvertedToGallon_ShouldReturnCorrectValue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Quantity<VolumeUnit> result = q1.ConvertTo(VolumeUnit.GALLON);

            Assert.AreEqual(0.26, result.Value);
            Assert.AreEqual(VolumeUnit.GALLON, result.Unit);
        }

        [TestMethod]
        public void GivenLitreAndMillilitre_WhenAdded_ShouldReturnCorrectResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Quantity<VolumeUnit> result = q1.Add(q2);

            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void GivenGallonAndLitre_WhenAddedWithTargetUnit_ShouldReturnCorrectResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.Add(q2, VolumeUnit.MILLILITRE);

            Assert.AreEqual(4785.41, result.Value);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void GivenZeroLitreAndZeroMillilitre_WhenCompared_ShouldReturnTrue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(0, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(0, VolumeUnit.MILLILITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenVolumeUnit_WhenGettingConversionFactor_ShouldReturnCorrectValue()
        {
            Assert.AreEqual(1.0, VolumeUnit.LITRE.GetConversionFactor());
            Assert.AreEqual(0.001, VolumeUnit.MILLILITRE.GetConversionFactor());
            Assert.AreEqual(3.78541, VolumeUnit.GALLON.GetConversionFactor());
        }
        [TestMethod]
        public void GivenSameGallons_WhenCompared_ShouldReturnTrue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(2, VolumeUnit.GALLON);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2, VolumeUnit.GALLON);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenDifferentLitres_WhenCompared_ShouldReturnFalse()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2, VolumeUnit.LITRE);

            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenMillilitre_WhenConvertedToLitre_ShouldReturnCorrectValue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Quantity<VolumeUnit> result = q1.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void GivenLitre_WhenConvertedToGallon_ShouldReturnCorrectValue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.ConvertTo(VolumeUnit.GALLON);

            Assert.AreEqual(1, result.Value);
            Assert.AreEqual(VolumeUnit.GALLON, result.Unit);
        }

        [TestMethod]
        public void GivenTwoLitres_WhenAdded_ShouldReturnCorrectResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.Add(q2);

            Assert.AreEqual(3, result.Value);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void GivenTwoMillilitres_WhenAdded_ShouldReturnCorrectResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);

            Quantity<VolumeUnit> result = q1.Add(q2);

            Assert.AreEqual(1000, result.Value);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void GivenLitreAndMillilitre_WhenAddedWithLitreTarget_ShouldReturnCorrectResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);

            Quantity<VolumeUnit> result = q1.Add(q2, VolumeUnit.LITRE);

            Assert.AreEqual(1.5, result.Value);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void GivenGallonAndLitre_WhenAdded_ShouldReturnCorrectResultInFirstUnit()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.Add(q2);

            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(VolumeUnit.GALLON, result.Unit);
        }

        [TestMethod]
        public void GivenVolume_WhenComparedWithNull_ShouldReturnFalse()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            Assert.IsFalse(q1.Equals(null));
        }

        [TestMethod]
        public void GivenSameReferenceVolume_WhenCompared_ShouldReturnTrue()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q1));
        }
        [TestMethod]
        public void GivenTwoLengths_WhenSubtracted_ShouldReturnCorrectResult()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(6, LengthUnit.INCHES);

            Quantity<LengthUnit> result = q1.Subtract(q2);

            Assert.AreEqual(9.5, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void GivenTwoWeights_WhenSubtracted_ShouldReturnCorrectResult()
        {
            Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(5, WeightUnit.KILOGRAM);
            Quantity<WeightUnit> q2 = new Quantity<WeightUnit>(500, WeightUnit.GRAM);

            Quantity<WeightUnit> result = q1.Subtract(q2);

            Assert.AreEqual(4.5, result.Value);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void GivenTwoVolumes_WhenSubtractedWithTargetUnit_ShouldReturnCorrectResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.Subtract(q2, VolumeUnit.MILLILITRE);

            Assert.AreEqual(3000, result.Value);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void GivenEqualQuantities_WhenSubtracted_ShouldReturnZero()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(1, LengthUnit.FEET);

            Quantity<LengthUnit> result = q1.Subtract(q2);

            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void GivenSmallerFirstQuantity_WhenSubtracted_ShouldReturnNegativeResult()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2, VolumeUnit.LITRE);

            Quantity<VolumeUnit> result = q1.Subtract(q2);

            Assert.AreEqual(-1, result.Value);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }
        [TestMethod]
        public void GivenTwoEqualWeights_WhenDivided_ShouldReturnOne()
        {
            Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            Quantity<WeightUnit> q2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            double result = q1.Divide(q2);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GivenTwoLengths_WhenDivided_ShouldReturnCorrectRatio()
        {
            Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            double result = q1.Divide(q2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenTwoVolumes_WhenDivided_ShouldReturnCorrectRatio()
        {
            Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(4, VolumeUnit.LITRE);
            Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(2, VolumeUnit.LITRE);

            double result = q1.Divide(q2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenSmallerFirstQuantity_WhenDivided_ShouldReturnLessThanOne()
        {
            Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(500, WeightUnit.GRAM);
            Quantity<WeightUnit> q2 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

            double result = q1.Divide(q2);

            Assert.AreEqual(0.5, result);
        }
        [TestMethod]
        public void GivenZeroDivisor_WhenDividing_ShouldThrowDivideByZeroException()
        {
            try
            {
                Quantity<VolumeUnit> q1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
                Quantity<VolumeUnit> q2 = new Quantity<VolumeUnit>(0, VolumeUnit.LITRE);

                double result = q1.Divide(q2);

                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void GivenNullQuantity_WhenSubtracting_ShouldThrowArgumentNullException()
        {
            try
            {
                Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

                Quantity<LengthUnit> result = q1.Subtract(null);

                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void GivenNullQuantity_WhenDividing_ShouldThrowArgumentNullException()
        {
            try
            {
                Quantity<WeightUnit> q1 = new Quantity<WeightUnit>(5, WeightUnit.KILOGRAM);

                double result = q1.Divide(null);

                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void GivenCelsiusAndFahrenheit_WhenCompared_ShouldReturnTrue()
        {
            Quantity<TemperatureUnit> q1 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);
            Quantity<TemperatureUnit> q2 = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void GivenCelsius_WhenConvertedToFahrenheit_ShouldReturnCorrectValue()
        {
            Quantity<TemperatureUnit> q1 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);

            Quantity<TemperatureUnit> result = q1.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(212, result.Value);
            Assert.AreEqual(TemperatureUnit.FAHRENHEIT, result.Unit);
        }
        [TestMethod]
        public void GivenKelvin_WhenConvertedToCelsius_ShouldReturnCorrectValue()
        {
            Quantity<TemperatureUnit> q1 = new Quantity<TemperatureUnit>(273.15, TemperatureUnit.KELVIN);

            Quantity<TemperatureUnit> result = q1.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(0, result.Value);
            Assert.AreEqual(TemperatureUnit.CELSIUS, result.Unit);
        }
        [TestMethod]
        public void GivenTemperature_WhenAdded_ShouldThrowInvalidOperationException()
        {
            try
            {
                Quantity<TemperatureUnit> q1 = new Quantity<TemperatureUnit>(20, TemperatureUnit.CELSIUS);
                Quantity<TemperatureUnit> q2 = new Quantity<TemperatureUnit>(10, TemperatureUnit.CELSIUS);

                Quantity<TemperatureUnit> result = q1.Add(q2);

                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void GivenTemperature_WhenSubtracted_ShouldThrowInvalidOperationException()
        {
            try
            {
                Quantity<TemperatureUnit> q1 = new Quantity<TemperatureUnit>(20, TemperatureUnit.CELSIUS);
                Quantity<TemperatureUnit> q2 = new Quantity<TemperatureUnit>(10, TemperatureUnit.CELSIUS);

                Quantity<TemperatureUnit> result = q1.Subtract(q2);

                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void GivenTemperature_WhenDivided_ShouldThrowInvalidOperationException()
        {
            try
            {
                Quantity<TemperatureUnit> q1 = new Quantity<TemperatureUnit>(20, TemperatureUnit.CELSIUS);
                Quantity<TemperatureUnit> q2 = new Quantity<TemperatureUnit>(10, TemperatureUnit.CELSIUS);

                double result = q1.Divide(q2);

                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}