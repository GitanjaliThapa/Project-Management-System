using System.ComponentModel.DataAnnotations;

namespace Milestone3Project.Models
{
    public class ProjectTask
    {
        public int ProjectTaskID { get; set; } // Required property
        public required int ProjectID { get; set; } // Required property
        public required string TaskName { get; set; } // Required property
        public required string TaskStatus { get; set; } // Required property

        // Navigation property to Project
        public required Project Project { get; set; } // Required navigation property
    }
}