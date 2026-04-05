using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myprojectpharmacy.Models
{
    public class Supplier
    {
        public  required int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public required string Phone { get; set; }

        [Required]
        [Display(Name = "Medications")]
        public required  string Medications { get; set; }
    }
}