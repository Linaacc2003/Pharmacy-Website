using System;
using System.ComponentModel.DataAnnotations;

namespace myprojectpharmacy.Models
{
    public class Patient
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

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [StringLength(10)]
        public required string Gender { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public required string PhoneNumber { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required string Address { get; set; }

        [Display(Name = "Medical History")]
        public required string MedicalHistory { get; set; }
    }
}
