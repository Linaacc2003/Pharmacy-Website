using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myprojectpharmacy.Models
{
    public class Pharmacist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "License Number")]
        public required string LicenseNumber { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public required string PhoneNumber { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(100)]
        public required string Address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
