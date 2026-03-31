namespace QuantityMeasurementApp.Models.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}