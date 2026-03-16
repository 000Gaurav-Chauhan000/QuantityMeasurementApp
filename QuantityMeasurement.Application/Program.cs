using System;
using QuantityMeasurementApp.Model.Models;
using QuantityMeasurementApp.Model.Units;
using QuantityMeasurement.Application.Services;
using QuantityMeasurement.Application.Interfaces;

namespace QuantityMeasurementApp.Application
{
    public class Program
    {
        public static void Main()
        {
            IMenu menu = new Menu();
            menu.ShowMenu();
        }
    }
}