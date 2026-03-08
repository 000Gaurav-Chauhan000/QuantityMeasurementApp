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
        public void GivenNegativeValue_WhenCreatingQuantity_ShouldThrowArgumentException()
        {
            try
            {
                Quantity<LengthUnit> q = new Quantity<LengthUnit>(-5, LengthUnit.FEET);

                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}