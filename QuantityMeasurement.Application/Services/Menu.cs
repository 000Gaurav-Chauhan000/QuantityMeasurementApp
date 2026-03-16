using QuantityMeasurement.Application.Interfaces;
using QuantityMeasurementApp.Model.Models;
using QuantityMeasurementApp.Model.Units;

namespace QuantityMeasurement.Application.Services
{
    public class Menu : IMenu
    {
        private readonly Utility utility = new Utility();

        public void ShowMenu()
        {
            Console.WriteLine("Select Quantity Type");
            Console.WriteLine("1 Length");
            Console.WriteLine("2 Weight");
            Console.WriteLine("3 Temperature");

            int type = ReadInt("Enter choice: ");

            Console.WriteLine("Select Operation");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 Subtract");
            Console.WriteLine("3 Divide");
            Console.WriteLine("4 Compare");
            Console.WriteLine("5 Convert");

            int operation = ReadInt("Enter choice: ");

            switch (type)
            {
                case 1:
                    HandleLength(operation);
                    break;

                case 2:
                    HandleWeight(operation);
                    break;

                case 3:
                    HandleTemperature(operation);
                    break;

                default:
                    Console.WriteLine("Invalid Quantity Type");
                    break;
            }
        }

        private void HandleLength(int operation)
        {
            if (operation == 5)
            {
                var q = ReadLengthQuantity();
                var target = ReadLengthUnit();
                var result = utility.ConvertLength(q, target);
                Console.WriteLine("Converted Result: " + result);
                return;
            }

            var q1 = ReadLengthQuantity();
            var q2 = ReadLengthQuantity();
            utility.HandleLength(operation, q1, q2);
        }

        private void HandleWeight(int operation)
        {
            if (operation == 5)
            {
                var q = ReadWeightQuantity();
                var target = ReadWeightUnit();
                var result = utility.ConvertWeight(q, target);
                Console.WriteLine("Converted Result: " + result);
                return;
            }

            var q1 = ReadWeightQuantity();
            var q2 = ReadWeightQuantity();
            utility.HandleWeight(operation, q1, q2);
        }

        private void HandleTemperature(int operation)
        {
            if (operation == 5)
            {
                var q = ReadTemperatureQuantity();
                var target = ReadTemperatureUnit();
                var result = utility.ConvertTemperature(q, target);
                Console.WriteLine("Converted Result: " + result);
                return;
            }

            var q1 = ReadTemperatureQuantity();
            var q2 = ReadTemperatureQuantity();
            utility.HandleTemperature(operation, q1, q2);
        }

        private Quantity<LengthUnit> ReadLengthQuantity()
        {
            double value = ReadDouble("Enter value: ");

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1 Feet");
            Console.WriteLine("2 Inches");
            Console.WriteLine("3 Yards");
            Console.WriteLine("4 Centimeters");

            int choice = ReadInt("Enter choice: ");

            LengthUnit unit = choice switch
            {
                1 => LengthUnit.FEET,
                2 => LengthUnit.INCHES,
                3 => LengthUnit.YARDS,
                4 => LengthUnit.CENTIMETERS,
                _ => throw new ArgumentException("Invalid Length Unit")
            };

            return new Quantity<LengthUnit>(value, unit);
        }

        private Quantity<WeightUnit> ReadWeightQuantity()
        {
            double value = ReadDouble("Enter value: ");

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1 Kilogram");
            Console.WriteLine("2 Gram");
            Console.WriteLine("3 Pound");

            int choice = ReadInt("Enter choice: ");

            WeightUnit unit = choice switch
            {
                1 => WeightUnit.KILOGRAM,
                2 => WeightUnit.GRAM,
                3 => WeightUnit.POUND,
                _ => throw new ArgumentException("Invalid Weight Unit")
            };

            return new Quantity<WeightUnit>(value, unit);
        }

        private Quantity<TemperatureUnit> ReadTemperatureQuantity()
        {
            double value = ReadDouble("Enter value: ");

            Console.WriteLine("Choose Unit:");
            Console.WriteLine("1 Celsius");
            Console.WriteLine("2 Fahrenheit");

            int choice = ReadInt("Enter choice: ");

            TemperatureUnit unit = choice switch
            {
                1 => TemperatureUnit.CELSIUS,
                2 => TemperatureUnit.FAHRENHEIT,
                _ => throw new ArgumentException("Invalid Temperature Unit")
            };

            return new Quantity<TemperatureUnit>(value, unit);
        }

        private LengthUnit ReadLengthUnit()
        {
            Console.WriteLine("Convert To:");
            Console.WriteLine("1 Feet");
            Console.WriteLine("2 Inches");
            Console.WriteLine("3 Yards");
            Console.WriteLine("4 Centimeters");

            int choice = ReadInt("Enter choice: ");

            return choice switch
            {
                1 => LengthUnit.FEET,
                2 => LengthUnit.INCHES,
                3 => LengthUnit.YARDS,
                4 => LengthUnit.CENTIMETERS,
                _ => throw new ArgumentException("Invalid Length Unit")
            };
        }

        private WeightUnit ReadWeightUnit()
        {
            Console.WriteLine("Convert To:");
            Console.WriteLine("1 Kilogram");
            Console.WriteLine("2 Gram");
            Console.WriteLine("3 Pound");

            int choice = ReadInt("Enter choice: ");

            return choice switch
            {
                1 => WeightUnit.KILOGRAM,
                2 => WeightUnit.GRAM,
                3 => WeightUnit.POUND,
                _ => throw new ArgumentException("Invalid Weight Unit")
            };
        }

        private TemperatureUnit ReadTemperatureUnit()
        {
            Console.WriteLine("Convert To:");
            Console.WriteLine("1 Celsius");
            Console.WriteLine("2 Fahrenheit");

            int choice = ReadInt("Enter choice: ");

            return choice switch
            {
                1 => TemperatureUnit.CELSIUS,
                2 => TemperatureUnit.FAHRENHEIT,
                _ => throw new ArgumentException("Invalid Temperature Unit")
            };
        }

        private int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        private double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
            }
        }
    }
}