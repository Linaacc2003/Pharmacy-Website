using myprojectpharmacy.Models;
using System.ComponentModel.DataAnnotations;

namespace myprojectpharmacy.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pharmacist")]
        public int PharmacistId { get; set; }

        public Pharmacist? Pharmacist { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        public Patient? Patient { get; set; }

        [Required]
        [Display(Name = "Medications")]
        [StringLength(500, ErrorMessage = "Medication list cannot exceed 500 characters.")]
        public required string MedicationList { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Issued")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateIssued { get; set; }
    }
}
