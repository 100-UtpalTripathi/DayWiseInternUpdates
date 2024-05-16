using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models
{
    public class User
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] PasswordHashKey { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public string Status { get; set; }
    }
}
