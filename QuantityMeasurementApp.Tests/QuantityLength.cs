using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthTest
    {
        [TestMethod]
        public void TestEquality_FeetToFeet_SameValue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength q2 = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_InchToInch_SameValue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.INCHES);
            QuantityLength q2 = new QuantityLength(1.0, LengthUnit.INCHES);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_FeetToInch_EquivalentValue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength q2 = new QuantityLength(12.0, LengthUnit.INCHES);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_DifferentValue()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength q2 = new QuantityLength(2.0, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_NullComparison()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(null));
        }

        [TestMethod]
        public void TestEquality_SameReference()
        {
            QuantityLength q1 = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q1));
        }
         [TestMethod]
        public void testEquality_YardToYard_SameValue()
        {
            var a = new QuantityLength(2.0, LengthUnit.YARDS);
            var b = new QuantityLength(2.0, LengthUnit.YARDS);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToYard_DifferentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.YARDS);
            var b = new QuantityLength(2.0, LengthUnit.YARDS);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToFeet_EquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.YARDS);
            var b = new QuantityLength(3.0, LengthUnit.FEET);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_FeetToYard_EquivalentValue()
        {
            var a = new QuantityLength(3.0, LengthUnit.FEET);
            var b = new QuantityLength(1.0, LengthUnit.YARDS);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToInches_EquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.YARDS);
            var b = new QuantityLength(36.0, LengthUnit.INCHES);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_InchesToYard_EquivalentValue()
        {
            var a = new QuantityLength(36.0, LengthUnit.INCHES);
            var b = new QuantityLength(1.0, LengthUnit.YARDS);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToFeet_NonEquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.YARDS);
            var b = new QuantityLength(2.0, LengthUnit.FEET);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimetersToCentimeters_SameValue()
        {
            var a = new QuantityLength(2.0, LengthUnit.CENTIMETERS);
            var b = new QuantityLength(2.0, LengthUnit.CENTIMETERS);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimetersToInches_EquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.CENTIMETERS);
            var b = new QuantityLength(0.393701, LengthUnit.INCHES);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_CentimetersToFeet_NonEquivalentValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.CENTIMETERS);
            var b = new QuantityLength(1.0, LengthUnit.FEET);

            Assert.IsFalse(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_AllUnits_ComplexScenario()
        {
            var yards = new QuantityLength(2.0, LengthUnit.YARDS);
            var feet = new QuantityLength(6.0, LengthUnit.FEET);
            var inches = new QuantityLength(72.0, LengthUnit.INCHES);

            Assert.IsTrue(yards.Equals(feet));
            Assert.IsTrue(feet.Equals(inches));
            Assert.IsTrue(yards.Equals(inches));
        }

        [TestMethod]
        public void testEquality_YardSameReference()
        {
            var a = new QuantityLength(2.0, LengthUnit.YARDS);
            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod]
        public void testEquality_YardNullComparison()
        {
            var a = new QuantityLength(2.0, LengthUnit.YARDS);
            Assert.IsFalse(a.Equals(null));
        }

        [TestMethod]
        public void testEquality_CentimetersSameReference()
        {
            var a = new QuantityLength(2.0, LengthUnit.CENTIMETERS);
            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod]
        public void testEquality_CentimetersNullComparison()
        {
            var a = new QuantityLength(2.0, LengthUnit.CENTIMETERS);
            Assert.IsFalse(a.Equals(null));
        }   
    }
}