using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models.DTOs.UserDTOs
{
    public class UserActivationDTO
    {
        [Required(ErrorMessage = "User ID is required.")]
        [Range(1, 999, ErrorMessage = "User ID must be between 100 and 999.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "IsActive status is required.")]
        public bool IsActive { get; set; }
    }
}
