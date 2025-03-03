using System.ComponentModel.DataAnnotations;

namespace Milestone3Project.Models
{
    public class Milestone
    {
        [Key]
        public required int MilestoneID { get; set; } // Required property

        [Required]
        public required string MilestoneName { get; set; } // Required property

        [Required]
        public required string MilestoneDescription { get; set; } // Required property

        [Required]  // Mark due date as required if applicable
        public required DateTime MilestoneDueDate { get; set; } // Required property

        // Foreign Key to Project
        public required int ProjectID { get; set; } // Required property

        // Navigation property to the related Project
        public required Project Project { get; set; } // Required navigation property
    }
}