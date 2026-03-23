using QuantityMeasurementApp.Repository.Implementations;
using QuantityMeasurementApp.Repository.Interfaces;
using QuantityMeasurementApp.Repository.Services;
using QuantityMeasurement.Model.DTO;
using QuantityMeasurement.Application.Interfaces;
using QuantityMeasurement.Application.Services;

namespace QuantityMeasurementApp.Application
{
    public class Program
    {
        public static void Main()
        {
            IQuantityMeasurementRepository repo =
                new QuantityMeasurementDbRepository();

            var service = new QuantityMeasurementServiceImpl(repo);
            IMenu menu=new Menu();
            menu.ShowMenu();

        }
    }
}