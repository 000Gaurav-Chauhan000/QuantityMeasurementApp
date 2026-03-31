using System.ComponentModel.DataAnnotations;

namespace QuantityMeasurement.Model.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}