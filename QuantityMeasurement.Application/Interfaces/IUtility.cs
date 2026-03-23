using QuantityMeasurement.Model.DTO;
namespace QuantityMeasurement.Application.Interfaces;

interface IUtility
{
    void Add();
    void Subtract();
    void Divide();
    void CompareLength();
    void CompareWeight();
    void CompareTemperature();
    void COnvert();
    QuantityDTO ReadQuantity();
    
}