using System.ComponentModel.DataAnnotations;

namespace myprojectpharmacy.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        [StringLength(50)]
        public string? Role { get; set; }
    }
}
