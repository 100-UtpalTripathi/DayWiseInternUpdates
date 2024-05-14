using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ExperienceInYears { get; set; }
        public string Specialization { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public string ContactNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
